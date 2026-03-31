using Abilities;
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

            var heroHealth = new Health(2);
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
                allAbilitiesConfigs: G.Configs.AbilitiesConfigs.AllAbilities);
            _abilityInventory = new AbilityInventoryPresenter(_abilityInventoryView, abilityInventoryModel);
            _abilityInventory.Load();

            // ========== Hero ==========

            var heroName = G.GameSessionProvider.SessionData.Hero;
            var heroPrefab = G.Configs.HeroesConfigs.GetHero(heroName).Prefab;
            var hero = Instantiate(heroPrefab, _location.HeroPosition, Quaternion.identity);
            hero.Init(_heroStats);

            // ========== MVP ==========

            var model = new CombatModel(
                hero: hero,
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _presenter.OpenNewLevelUpgradePopUps();
            }

            else if (Input.GetKeyDown(KeyCode.S))
                Debug.Log(_heroStats.ToString());
        }
    }
}