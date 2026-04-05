using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Combat
{
    public class CombatPresenter : IDisposable
    {
        private readonly CompositeDisposable _disposables = new();

        private CombatView _view;
        private CombatModel _model;

        public CombatPresenter(CombatView view, CombatModel model)
        {
            _view = view;
            _model = model;

            SetupSubscriptions();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void SetupSubscriptions()
        {
            _view.AttackButtonPressedSignal
                .ThrottleFirst(TimeSpan.FromSeconds(0.25f))
                .Subscribe(_ => HandleAttack())
                .AddTo(_disposables);

            _view.DiscardButtonPressedSignal
                .Subscribe(_ => HandleDiscard())
                .AddTo(_disposables);

            _view.DeckButtonPressedSignal
                .Subscribe(_ => HandleDeckOpen())
                .AddTo(_disposables);

            _view.DrawButtonPressedSignal
                .Subscribe(_ => HandleDraw())
                .AddTo(_disposables);

            _model.ChangedSignal
                .Subscribe(_ => UpdateView())
                .AddTo(_disposables);

            _model.Hero.DeathSignal
                .Subscribe(_ => HandleLevelLosing())
                .AddTo(_disposables);

            _model.Enemy.DeathSignal
                .Subscribe(_ => HandleLevelPassing())
                .AddTo(_disposables);
        }

        // ================ Attack ================

        private void HandleAttack()
        {
            if (_model.UnitsOnFieldCount == 0)
            {
                G.UIRoot.ShowMessage("Сначала составь предложение"); // Loc.
                return;
            }

            var sentence = string.Join(" ", _model.FieldWordUnitsGroup.AllWordUnits.Select(w => w.GetWordText()));
            var validationResult = _model.GrammarValidator.Validate(sentence);

            /*if (!validationResult.IsValid)
            {
                var hintMessage = G.Configs.GrammarHintsConfigs.GetMessage(validationResult.HintCode);
                _view.ShowMessage(hintMessage);
                return;
            }*/

            ExecuteAttackSequence(validationResult);
        }

        private void ExecuteAttackSequence(ValidationResult validationResult)
        {
            _view.DisableControls();

            _model.PointsCounter
                .StartCounting(_model.FieldWordUnitsGroup.AllWordUnits)
                .Select(points =>
                {
                    var multipliers = _model.PointMultiplierResolver.GetMultipliers(validationResult);
                    return _model.PointsCounter
                        .AddMultipliers(multipliers, _view.DefaultPointsShowingPosition)
                        .Select(_ => points);
                })
                .Switch()
                .Subscribe(points => CompleteAttack(points))
                .AddTo(_disposables);
        }

        private void CompleteAttack(Points points)
        {
            _model.Hero.Attack();

            points.Attack(_model.Enemy.Center)
                .Subscribe(value =>
                {
                    _model.HeroStats.TryApplyVampirism();
                    DiscardFieldWords();
                    ApplyDamageToEnemy(value);
                })
                .AddTo(_disposables);
        }

        private void ApplyDamageToEnemy(int pointsValue)
        {
            var enemy = _model.Enemy;

            enemy.TakeDamage(pointsValue, out var animationDuration);
            G.CameraShaker.MidShake();

            var experience = _model.HeroStats.CalculateExperience(pointsValue);
            _model.Hero.AddExperience(experience);

            Observable
                .Timer(TimeSpan.FromSeconds(animationDuration + 0.2f))
                .Subscribe(_ =>
                {
                    if (enemy.IsAlive)
                    {
                        EnemyRetaliate(enemy, pointsValue);
                    }
                })
                .AddTo(_disposables);
        }

        private void EnemyRetaliate(Enemy enemy, int pointsValue)
        {
            enemy.Attack().Subscribe(_ =>
            {
                if (_model.HeroStats.IsChanceSuccessWithRage(StatName.Dodge, StatName.RageDodge))
                {
                    if (_model.HeroStats.IsExistAndNotZero(StatName.SpikesPower))
                    {
                        var spikesDamage = _model.HeroStats.GetStatValue(StatName.SpikesPower);
                        enemy.TakeDamage((int)spikesDamage, out var _);
                    }

                    _model.Hero.TakeDamage();
                }

                if (_model.Hero.IsAlive)
                {
                    if (_model.HeroStats.Experience.IsNextLevelReached)
                    {
                        _model.HeroStats.Experience.LevelUp();
                        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
                            OpenNewLevelUpgradePopUps());
                    }
                    else
                        _view.EnableControls();
                }

                _model.Hero.SaveStats();
            });
        }

        // ================ Upgrades ================

        public void OpenNewLevelUpgradePopUps()
        {
            _view.DisableControls();
            
            var abilitySelectionPopUp = G.PopUpsProvider.OpenAbilitySelectionPopUp(
                G.AbilityProvider.GetAbilitiesForSelection(_model.AbilityInventory.GetAcquiredAbilities()));

            abilitySelectionPopUp.AbilitySelectedSignal.Subscribe(abilityName =>
            {
                _model.AbilityInventory.AddAbility(abilityName);
                _model.AbilityInventory.Save();
                _model.Hero.SaveStats();
            });

            abilitySelectionPopUp.CloseSignal.Subscribe(_ =>
            {
                var random = new System.Random();
                var wordUnitSelectionPopUp = G.PopUpsProvider.OpenWordUnitSelectionPopUp(
                    _model.AvailableWordUnitsConfigs.OrderBy(x => random.Next()).Take(3));

                wordUnitSelectionPopUp.WordSelectedSignal.Subscribe(configs =>
                    _model.Deck.Add(configs));

                wordUnitSelectionPopUp.CloseSignal.Subscribe(__ =>
                    _view.EnableControls());
            });
        }

        // ================ Discard ================

        private void HandleDiscard()
        {
            if (_model.UnitsOnFieldCount <= 0)
            {
                G.UIRoot.ShowMessage("Не вижу ни одного слова"); // Loc.
                return;
            }

            if (_model.Discards.CurrentValue > 0)
                _model.Discards.DecreaseOne();
            else if (_model.Hero.IsMoreThanOneHealthUnit)
                _model.Hero.SubstractOneHealthUnit();
            else
            {
                G.UIRoot.ShowMessage("Ты так сильно хочешь умереть?"); // Loc.
                return;
            }

            DiscardFieldWords();
            _model.Hero.SaveStats();
        }

        private void DiscardFieldWords()
        {
            var discardedWords = _model.FieldWordUnitsGroup.Discard(_view.DeckButtonPosition);
            _model.HandWordUnitsGroup.DestroyLinkedBackplates(discardedWords);
            _model.HandWordUnitsGroup.Layout.Arrange();
            _model.Deck.Add(discardedWords.Select(w => w.Configs));
        }

        // ================ Open Deck ================

        private void HandleDeckOpen()
        {
            _view.DisableControls();

            G.PopUpsProvider.OpenDeckPopUp(_model.Deck.AllWordUnits)
                .CloseSignal.Subscribe(_ => _view.EnableControls())
                .AddTo(_disposables);
        }

        // ================ Draw ================

        private void HandleDraw()
        {
            var capacityLeft = (int)_model.HandCapacity.Max - _model.UnitsInHandCount;
            if (capacityLeft <= 0)
            {
                G.UIRoot.ShowMessage("Все места на поле уже заняты"); // Loc.
                return;
            } 
            else if (!_model.Deck.HasAnyWordUnit)
            {
                G.UIRoot.ShowMessage("Мешок пуст, ни одного слова"); // Loc.
                return;
            }

            if (_model.Draws.CurrentValue > 0)
                _model.Draws.DecreaseOne();
            else if (_model.Hero.IsMoreThanOneHealthUnit)
                _model.Hero.SubstractOneHealthUnit();
            else
            {
                G.UIRoot.ShowMessage("Ты так сильно хочешь умереть?"); // Loc.
                return;
            }

            DrawWords();
        }

        public void DrawWords()
        {
            var capacityLeft = (int)_model.HandCapacity.Max - _model.UnitsInHandCount;
            var wordUnitsConfigs = new List<WordUnitConfigs>();
            for (int i = 0; i < capacityLeft; i++)
            {
                if (!_model.Deck.HasAnyWordUnit) break;

                var wordUnitConfigs = _model.Deck.DrawRandom();
                if (wordUnitConfigs == null) continue;

                var createdWord = G.WordUnitFactory.Create(wordUnitConfigs, _view.DrawWordUnitsButtonPosition);
                _model.HandWordUnitsGroup.Add(createdWord);
            }
            _model.HandWordUnitsGroup.Layout.Arrange();
            _model.Hero.SaveStats();
        }

        // ================ Level Completion ================

        private void HandleLevelPassing()
        {
            Observable.Timer(TimeSpan.FromSeconds(2f)).Subscribe(_ =>
            {
                if (!_model.Hero.IsAlive) return;
                _view.DisableControls();
                G.PopUpsProvider.OpenCombatVictoryPopUp();
            });
        }

        private void HandleLevelLosing()
        {
            Observable.Timer(TimeSpan.FromSeconds(1f)).Subscribe(_ =>
            {
                _view.DisableControls();
                G.PopUpsProvider.OpenCombatDefeatPopUp();
             });
        }

        // ================ UI ================

        private void UpdateView()
        {
            _view.UpdateDiscardPoints((int)_model.Discards.CurrentValue);
            _view.UpdateDrawPoints((int)_model.Draws.CurrentValue);
            _view.UpdateAvailableWordsOnField(_model.AvailableWordsOnFieldCount);
            _view.UpdateHandCapacity(_model.UnitsInHandCount, (int)_model.HandCapacity.Max);
        }
    }
}