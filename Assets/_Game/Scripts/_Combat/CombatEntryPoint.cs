using Abilities;
using Commands;
using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using R3;
using System;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private CombatView _view;
        [SerializeField] private AbilityInventoryView _abilityInventoryView;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;
        [SerializeField] private Location _location;
        [SerializeField] private CameraShaker _cameraShaker;

        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs; // Temp.
        [SerializeField] private AbilityConfigs[] _abilitiesConfigs; // Temp.

        private CombatPresenter _presenter;
        private AbilityInventoryPresenter _abilityInventory;
        private Deck _deck;

        private Stats _heroStats; // Temp.

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.CameraShaker = _cameraShaker;
            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            G.WordUnitFactory = new WordUnitFactory();
            G.PointsFactory = new PointsFactory();

            _deck = new Deck(_wordUnitsConfigs);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);
            var pointsCounter = new PointsCounter(_location.PointsAccumulationPosition);

            // ========== Stats ==========

            var heroHealth = new Health(1);
            var heroArmor = new Armor(0);
            var heroExperience = new Experience(G.Configs.StatsConfigs.ExperienceLevelDatas);

            var discards = new Stat(StatName.DiscardsCount, 3, 3);
            var draws = new Stat(StatName.DrawsCount, 5, 5);
            var fieldCapacity = new Stat(StatName.FieldCapacity, 5, 5);
            var handCapacity = new Stat(StatName.HandCapacity, 10, 10);

            _view.HeroHealthStatView.Init(heroHealth);
            _view.HeroArmorStatView.Init(heroArmor);
            _view.HeroExperienceStatView.Init(heroExperience);

            _heroStats = new Stats(
                heroHealth, 
                heroArmor, 
                heroExperience, 
                discards,
                draws,
                fieldCapacity,
                handCapacity);

            var pointMultiplierResolver = new PointMultipliersResolver(
                _heroStats, G.Configs.PointMultiplierNamesConfigs);

            // ========== Abilities ==========

            var abilityInventoryModel = new AbilityInventoryModel(
                allConfigs: _abilitiesConfigs);
            _abilityInventory = new AbilityInventoryPresenter(_abilityInventoryView, abilityInventoryModel);

            // ========== MVP ==========

            var model = new CombatModel(
                heroStats: _heroStats,
                pointMultiplierResolver: pointMultiplierResolver,
                deck: _deck,
                handWordUnitsGroup: _handWordUnitsGroup,
                fieldWordUnitsGroup: _fieldWordUnitsGroup,
                grammarValidator: grammarValidator,
                pointsCounter: pointsCounter,
                location: _location,
                abilityInventory: _abilityInventory,
                availableWordUnitsConfigs: _wordUnitsConfigs);
            _presenter = new CombatPresenter(_view, model);

            // ========== Hero ==========

            _location.Hero.Init(_heroStats);

            // ========== Commands ==========

            InitCommands(_heroStats);

            // ========== Level Passing ==========

            _location.AllEnemiesDeathSignal.Subscribe(_ =>
            {
                Observable.Timer(TimeSpan.FromSeconds(3f)).Subscribe(_ =>
                {
                    _view.DisableControls();
                    G.PopUpsProvider.OpenCombatVictoryPopUp();
                });
            });

            // ========== Start Game ==========

            _view.EnableControls();
            _view.PressDrawButton();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }

        private void OnDestroy()
        {
            _presenter?.Dispose();
        }

        private void InitCommands(Stats heroStats)
        {
            G.CommandProcessor = new CombatCommandProcessor();
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseArmorCommandHandler(heroStats.Armor));
            G.CommandProcessor.RegisterHandler(
                new AbilityRestoreHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new AbilityRestoreArmorCommandHandler(heroStats.Armor));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseVampirismCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseVampirismPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseExperiencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseHandCapacityCommandHandler(heroStats.GetStat(StatName.HandCapacity)));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFieldCapacityCommandHandler(heroStats.GetStat(StatName.FieldCapacity)));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDrawsCountCommandHandler(heroStats.GetStat(StatName.DrawsCount)));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDiscardsCountCommandHandler(heroStats.GetStat(StatName.DiscardsCount)));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDeclarativeSentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseInterrogativeSentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseExclamatorySentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseThreeWordsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFourWordsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseAttackPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDodgeCommandhandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseRageAttackCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseCriticalAttackCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseCriticalAttackPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseRageDodgeCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreasePronounsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseLinkingVerbsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseAdjectivesPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFullHealthAttackCommandHandler(heroStats));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _presenter.OpenNewLevelUpgradePopUps();
            }

            else if (Input.GetKeyDown(KeyCode.I))
                G.CommandProcessor.Process(new AbilityIncreaseHealthCommand(1));

            else if (Input.GetKeyDown(KeyCode.S))
                Debug.Log(_heroStats.ToString());
        }
    }
}