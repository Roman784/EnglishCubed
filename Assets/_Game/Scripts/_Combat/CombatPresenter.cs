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

        private void HandleAttack()
        {
            var sentence = string.Join(" ", _model.FieldWordUnitsGroup.AllWordUnits.Select(w => w.GetWordText()));
            var validationResult = _model.GrammarValidator.Validate(sentence);

            if (!validationResult.IsValid)
            {
                var hintMessage = G.Configs.GrammarHintsConfigs.GetMessage(validationResult.HintCode);
                _view.ShowMessage(hintMessage);
                return;
            }

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
            points.Attack(_model.Location.FirstEnemyPosition).Subscribe(_ =>
            {
                DiscardFieldWords();
                _view.EnableControls();
            })
            .AddTo(_disposables);
        }

        private void HandleDiscard()
        {
            if (_model.DiscardPoints <= 0 || _model.UnitsOnFieldCount <= 0) return;

            _model.SpendDiscardPoint();
            DiscardFieldWords();
        }

        private void DiscardFieldWords()
        {
            var discardedWords = _model.FieldWordUnitsGroup.Discard(_view.DeckButtonPosition);
            _model.HandWordUnitsGroup.DestroyLinkedBackplates(discardedWords);
            _model.HandWordUnitsGroup.Layout.Arrange();
            _model.Deck.Add(discardedWords.Select(w => w.Configs));
        }

        private void HandleDeckOpen()
        {
            _view.DisableControls();

            G.PopUpsProvider.OpenDeckPopUp(_model.Deck.AllWordUnits)
                .CloseSignal.Subscribe(_ => _view.EnableControls())
                .AddTo(_disposables);
        }

        private void HandleDraw()
        {
            var capacityLeft = _model.MaxHandCapacity - _model.UnitsInHandCount;
            if (capacityLeft <= 0 || _model.DrawPoints <= 0) return;
             
            if (_model.Deck.HasAnyWordUnit)
                _model.SpendDrawPoint();

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

        private void UpdateView()
        {
            _view.UpdateDiscardPoints(_model.DiscardPoints);
            _view.UpdateDrawPoints(_model.DrawPoints);
            _view.UpdateAvailableWordsOnField(_model.AvailableWordsOnFieldCount);
            _view.UpdateHandCapacity(_model.UnitsInHandCount, _model.MaxHandCapacity);
        }
    }
}