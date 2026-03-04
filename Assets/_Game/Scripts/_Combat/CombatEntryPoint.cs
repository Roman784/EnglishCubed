using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using Utils;
using static UnityEngine.Rendering.STP;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;
        [SerializeField] private CombatHUD _mainHUD;

        [SerializeField] private StatCellsView _heroHealthStatView;
        [SerializeField] private StatCellsView _heroArmorStatView;
        [SerializeField] private StatBarView _heroExperienceStatView;

        [SerializeField] private PointsCounter _pointsCounter;
        [SerializeField] private Location _location;

        [SerializeField] private CameraShaker _cameraShaker;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.CameraShaker = _cameraShaker;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            _fieldWordUnitsGroup.SetMaxAvailableWordsCount(5);
            _fieldWordUnitsGroup.SetDiscardPointsCount(3);

            // ========== Deck ==========
            var deck = new Deck(_wordUnitsConfigs);

            /*var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab, _handWordUnitsGroup.Layout.Container.position, Quaternion.identity)
                    .SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsGroup.SetInitialWordUnits(wordUnits);*/



            _mainHUD.AttackButtonPressedSignal.ThrottleFirst(System.TimeSpan.FromSeconds(0.25f)).Subscribe(_ =>
            {
                var sentence = string.Join(" ", _fieldWordUnitsGroup.AllWordUnits.Select(w => w.GetWordText()));
                var res = grammarValidator.Validate(sentence);
                if (!res.IsValid)
                {
                    G.UIRoot.ShowMessage(G.Configs.GrammarHintsConfigs.GetMessage(res.HintCode));
                }
                else
                {
                    G.WordUnitsMovementProvider.Disable();

                    _pointsCounter.StartCounting(_fieldWordUnitsGroup.AllWordUnits, _location.PointsAccumulationPoint)
                    .Subscribe(accumulativePoints =>
                    {
                        var multipliers = new List<PointsMultiplierData>()
                        {
                        new PointsMultiplierData(2f, "Вопрос "),
                        new PointsMultiplierData(1.5f, "Отрицание "),
                        new PointsMultiplierData(1.5f, "Ещё что-то "),
                        };

                        _pointsCounter.AddMultipliers(multipliers, _fieldWordUnitsGroup.WordUnitsPointsPoisition).Subscribe(_ =>
                        {
                            accumulativePoints.Attack(_location.FirstEnemyPosition).Subscribe(_ =>
                            {
                                var discarderWords = _fieldWordUnitsGroup.Discard(_mainHUD.DeckButtonPosition);
                                _handWordUnitsGroup.DestroyLinkedBackplates(discarderWords);
                                _handWordUnitsGroup.Layout.Arrange();

                                G.WordUnitsMovementProvider.Enable();
                            });
                        });
                    });
                }
            });

            _mainHUD.DiscardButtonPressedSignal.Subscribe(_ =>
            {
                if (_fieldWordUnitsGroup.DiscardPointsCount > 0 && _fieldWordUnitsGroup.AllWordUnitsCount > 0)
                {
                    _fieldWordUnitsGroup.SpendDiscardPoint();
                    var discarderWords = _fieldWordUnitsGroup.Discard(_mainHUD.DeckButtonPosition);
                    _handWordUnitsGroup.DestroyLinkedBackplates(discarderWords);
                    _handWordUnitsGroup.Layout.Arrange();
                }
            });

            _mainHUD.DeckButtonPressedSignal.Subscribe(_ => 
            {
                _handWordUnitsGroup.Layout.GravitationalPuller.Disable();
                _fieldWordUnitsGroup.Layout.GravitationalPuller.Disable();

                G.PopUpsProvider.OpenDeckPopUp(deck.AllWordUnits).CloseSignal.Subscribe(_ =>
                {
                    _handWordUnitsGroup.Layout.GravitationalPuller.Enable();
                    _fieldWordUnitsGroup.Layout.GravitationalPuller.Enable();
                });
            });

            _mainHUD.DrawWordUnitsButtonPressedSignal.Subscribe(_ =>
            {
                var wordUnitConfigs = deck.GetRandom();
                if (wordUnitConfigs != null)
                {
                    deck.Remove(wordUnitConfigs);
                    var newWordUnit = Instantiate(_wordUnitPrefab, _mainHUD.DrawWordUnitsButtonPosition, Quaternion.identity)
                        .SetConfigs(wordUnitConfigs);
                    _handWordUnitsGroup.Add(newWordUnit);
                    _handWordUnitsGroup.Layout.Arrange();
                }
            });

            // ========== Hero Stats ==========
            var heroHealth = new Health(5, 5);
            var heroArmor = new Armor(5, 5);
            var heroExperience = new Experience(0, 500);

            _heroHealthStatView.Init(heroHealth);
            _heroArmorStatView.Init(heroArmor);
            _heroExperienceStatView.Init(heroExperience);

            G.HeroStats = new HeroStats(heroHealth, heroArmor, heroExperience);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        } 
    }
}