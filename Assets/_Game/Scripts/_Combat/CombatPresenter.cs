using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using R3;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using DG.Tweening;

namespace Combat
{
    public class CombatPresenter : IDisposable
    {
        private readonly CompositeDisposable _disposables = new();

        private CombatView _view;
        private CombatModel _model;

        public CombatPresenter( CombatView view, CombatModel model)
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

            ExecuteAttackSequence();
        }

        private void ExecuteAttackSequence()
        {
            _view.DisableControls();

            _model.PointsCounter.StartCounting(_model.FieldWordUnitsGroup.AllWordUnits)
                .Subscribe(accumulativePoints =>
                {
                    var multipliers = GetMultipliers();

                    _model.PointsCounter.AddMultipliers(multipliers, _view.DefaultPointsShowingPosition)
                        .Subscribe(_ => CompleteAttack(accumulativePoints))
                        .AddTo(_disposables);
                })
                .AddTo(_disposables);
        }

        private IEnumerable<PointsMultiplierData> GetMultipliers()
        {
            return new List<PointsMultiplierData>()
            {
                new PointsMultiplierData(2f, "Вопрос "),
                new PointsMultiplierData(1.5f, "Отрицание "),
                new PointsMultiplierData(1.5f, "Ещё что-то "),
            };
        }

        private void CompleteAttack(Points points)
        {
            var hero = _model.Location.Hero;
            hero.Animator.PlayAttack();
            points.Attack(_model.Location.FirstEnemy.Center).Subscribe(pointsValue =>
            {
                DiscardFieldWords();
                G.CameraShaker.MidShake();

                var enemy = _model.Location.FirstEnemy;
                var enemyDamageDuration = enemy.Animator.PlayDamage();

                Observable.Timer(TimeSpan.FromSeconds(enemyDamageDuration)).Subscribe(_ =>
                {
                    var enemyAttackDuration = enemy.Animator.PlayAttack();

                    enemy.OnAttackEvent.Subscribe(_ =>
                    {
                        hero.TakeDamage();
                        if (hero.CurrentHealth > 0)
                        {
                            G.HeroStats.Experience.Add(pointsValue);
                            _view.EnableControls();
                        }
                    });
                })
                .AddTo(_disposables);
            })
            .AddTo(_disposables);
        }

        private void ExchangeAttacks()
        {

        }

        // ================ Discard ================

        private void HandleDiscard()
        {
            if (_model.UnitsOnFieldCount <= 0)
            {
                G.UIRoot.ShowMessage("Не вижу ни одного слова"); // Loc.
                return;
            }

            if (_model.DiscardPoints > 0)
                _model.SpendDiscardPoint();
            else if (G.HeroStats.Health.CurrentValue > 1)
                G.HeroStats.Health.DecreaseOne();
            else
            {
                G.UIRoot.ShowMessage("Ты так сильно хочешь умереть?"); // Loc.
                return;
            }

            DiscardFieldWords();
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
            var capacityLeft = _model.MaxHandCapacity - _model.UnitsInHandCount;
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

            if (_model.DrawPoints > 0)
                _model.SpendDrawPoint();
            else if (G.HeroStats.Health.CurrentValue > 1)
                G.HeroStats.Health.DecreaseOne();
            else
            {
                G.UIRoot.ShowMessage("Ты так сильно хочешь умереть?"); // Loc.
                return;
            }

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
        }

        // ================ UI ================

        private void UpdateView()
        {
            _view.UpdateDiscardPoints(_model.DiscardPoints);
            _view.UpdateDrawPoints(_model.DrawPoints);
            _view.UpdateAvailableWordsOnField(_model.AvailableWordsOnFieldCount);
            _view.UpdateHandCapacity(_model.UnitsInHandCount, _model.MaxHandCapacity);
        }
    }
}