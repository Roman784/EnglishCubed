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
using EncountersMap;

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

        private CombatPresenter _presenter;
        private AbilityInventoryPresenter _abilityInventory;
        private Deck _deck;

        private Stats _heroStats; // Temp.

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            UnityEngine.Random.InitState(G.GameSessionProvider.SessionData.Seed);

            G.CameraShaker = _cameraShaker;
            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            G.WordUnitFactory = new WordUnitFactory();
            G.PointsFactory = new PointsFactory();

            var sessionData = G.GameSessionProvider.SessionData;
            var heroName = sessionData.Hero;
            var heroConfigs = G.Configs.HeroesConfigs.GetHero(heroName);

            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);
            var pointsCounter = new PointsCounter(_location.PointsAccumulationPosition);

            // ========== Game Producer ==========

            G.GameProducer.Context.EncounterName = enterParams.EncounterName;
            G.GameProducer.Context.EncounterNumber = enterParams.EncounterNumber;

            // ========== Deck ==========

            IEnumerable<WordUnitConfigs> wordUnitsInDeck;
            if (G.SessionData.WordsInDeck.Count == 0)
                wordUnitsInDeck = G.GameProducer.WordUnits.GetWords(20);
            else
                wordUnitsInDeck = G.Configs.LexiconConfigs.AllWords.Where
                    (w => G.SessionData.WordsInDeck.Contains(w.Name));
            _deck = new Deck(wordUnitsInDeck);

            // ========== Stats ==========

            var discards = new StatData() { Name = StatName.DiscardsCount, Value = 3, Max = 3 };
            var draws = new StatData() { Name = StatName.DrawsCount, Value = 4, Max = 4 };
            var fieldCapacity = new StatData() { Name = StatName.FieldCapacity, Value = 5, Max = 5 };
            var handCapacity = new StatData() { Name = StatName.HandCapacity, Value = 10, Max = 10 };

            var experienceLevelData = G.Configs.StatsConfigs.ExperienceLevelDatas;
            var heroExperience = new Experience(
                experienceLevelData, sessionData.Experience.CurrentValue, sessionData.Experience.Level);

            var initialStats = new List<StatData>
            {
                discards,
                draws,
                fieldCapacity,
                handCapacity
            };
            initialStats.AddRange(heroConfigs.InitialStats);

            _heroStats = new Stats(initialStats, sessionData.Stats);
            _heroStats.SetStat(heroExperience);

            _view.HeroHealthStatView.Init(_heroStats.Health);
            _view.HeroArmorStatView.Init(_heroStats.Armor);
            _view.HeroExperienceStatView.Init(_heroStats.Experience);

            var pointMultiplierResolver = new PointMultipliersResolver(
                _heroStats, G.Configs.PointMultiplierNamesConfigs);

            // ========== Abilities ==========

            var abilityInventoryModel = new AbilityInventoryModel(
                allAbilitiesConfigs: G.Configs.AbilitiesConfigs.AllAbilities,
                heroStats: _heroStats);
            _abilityInventory = new AbilityInventoryPresenter(_abilityInventoryView, abilityInventoryModel);
            _abilityInventory.Load();

            // ========== Hero ==========

            var heroPrefab = heroConfigs.Prefab;
            var hero = Instantiate(heroPrefab, _location.HeroPosition, Quaternion.identity);
            hero.Init(_heroStats);

            // ========== Enemy ==========

            var enemySpec = G.GameProducer.Enemy.GetEnemy();
            var enemyPrefab = enemySpec.EnemyConfigs.Prefab;
            var enemyCurrentHealth = enemySpec.CurrentHealth;
            var enemyMaxHealth = enemySpec.MaxHealth;
            var enemy = Instantiate(enemyPrefab, _location.EnemyPosition, Quaternion.identity);
            enemy.Init(new Stats(new Health(enemyCurrentHealth, enemyMaxHealth)));

            // ========== MVP ==========

            var model = new CombatModel(
                enterParams: enterParams,
                hero: hero,
                enemy: enemy,
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

            // ========== Start Game ==========

            G.GameSessionProvider.SetIsInEncounter(true);
            G.GameSessionProvider.SetCurrentEncounterName(enterParams.EncounterName);
            G.GameSessionProvider.SetCurrentEncounterNumber(enterParams.EncounterNumber);

            if (!G.SessionData.IsEnemyExist)
            {
                G.GameSessionProvider.SetEnemy(enemySpec.EnemyConfigs.Name);
                G.GameSessionProvider.SetCurrentEnemyHealth(enemySpec.CurrentHealth);
                G.GameSessionProvider.SetMaxEnemyHealth(enemySpec.MaxHealth);
                G.GameSessionProvider.SetIsEnemyExist(true);
            }

            _view.EnableControls();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }

        private void OnDestroy()
        {
            _deck?.Dispose();
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