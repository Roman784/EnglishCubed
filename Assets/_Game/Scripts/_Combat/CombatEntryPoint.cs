using Abilities;
using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using R3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private CombatView _view;
        [SerializeField] private AbilityInventoryView _abilityInventoryView;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;

        private CombatPresenter _presenter;
        private AbilityInventoryPresenter _abilityInventory;
        private Deck _deck;

        private Stats _heroStats;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            UnityEngine.Random.InitState(G.GameSessionProvider.SessionData.Seed);

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            G.WordUnitFactory = new WordUnitFactory();
            G.PointsFactory = new PointsFactory();

            var sessionData = G.GameSessionProvider.SessionData;
            var heroName = sessionData.Hero;
            var heroConfigs = G.Configs.HeroesConfigs.GetHero(heroName);

            var levelName = G.SessionData.Level;
            var levelConfigs = G.Configs.LevelsConfigs.GetLevelConfigs(levelName);

            var grammarValidator = new GrammarValidator();

            // ========== Game Producer ==========

            G.GameProducer.Context.EncounterName = enterParams.EncounterName;
            G.GameProducer.Context.EncounterNumber = enterParams.EncounterNumber;
            G.GameProducer.Context.LexiconPool = new List<WordUnitConfigs>(levelConfigs.LexiconPool);
            G.GameProducer.Context.AbilitiesPool = new List<AbilityConfigs>(levelConfigs.AbilitiesPool);

            // ======== Hand ==========

            IEnumerable<WordUnit> handWordUnits = null;
            if (G.SessionData.WordsInHand.Count != 0)
                handWordUnits = G.SessionData.WordsInHand.Select(w => 
                    G.WordUnitFactory.Create(G.Configs.LexiconConfigs.GetByName(w), Vector2.zero));
            _handWordUnitsGroup.Init(handWordUnits);
            _handWordUnitsGroup.ChangedSignal
                .Subscribe(_ => G.GameSessionProvider.SetWordsInHand(_handWordUnitsGroup.GetWords()))
                .AddTo(this);

            // ========== Deck ==========

            IEnumerable<WordUnitConfigs> wordUnitsInDeck = null;
            if (G.SessionData.WordsInDeck.Count == 0)
                wordUnitsInDeck = G.GameProducer.WordUnits.GetWords(25);
            else
                wordUnitsInDeck = G.SessionData.WordsInDeck.Select
                    (w => G.Configs.LexiconConfigs.AllWords.First(wc => wc.Name == w));
            _deck = new Deck(wordUnitsInDeck);

            // ========== Stats ==========

            var discards = new StatData() { Name = StatName.DiscardsCount, Value = 3, Max = 3 };
            var draws = new StatData() { Name = StatName.DrawsCount, Value = 4, Max = 4 };
            var fieldCapacity = new StatData() { Name = StatName.FieldCapacity, Value = 5, Max = 5 };
            var handCapacity = new StatData() { Name = StatName.HandCapacity, Value = 15, Max = 15 };

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

            // ========== Location ==========

            var location = Instantiate(levelConfigs.LocationPrefab);
            G.CameraShaker = location.CameraShaker;

            // ========== Points ==========

            var pointsCounter = new PointsCounter(location.PointsAccumulationPosition);

            // ========== Hero ==========

            var heroPrefab = heroConfigs.Prefab;
            var hero = Instantiate(heroPrefab, location.HeroPosition, Quaternion.identity);
            hero.Init(_heroStats);

            // ========== Enemy ==========

            var enemySpec = G.GameProducer.Enemy.GetEnemy();
            var enemyPrefab = enemySpec.EnemyConfigs.Prefab;
            var enemyCurrentHealth = enemySpec.CurrentHealth;
            var enemyMaxHealth = enemySpec.MaxHealth;
            var enemy = Instantiate(enemyPrefab, location.EnemyPosition, Quaternion.identity);
            enemy.Init(new Stats(new Health(enemyCurrentHealth, enemyMaxHealth)));

            // ========== MVP ==========

            var model = new CombatModel(
                levelConfigs: levelConfigs,
                enterParams: enterParams,
                hero: hero,
                enemy: enemy,
                pointMultiplierResolver: pointMultiplierResolver,
                deck: _deck,
                handWordUnitsGroup: _handWordUnitsGroup,
                fieldWordUnitsGroup: _fieldWordUnitsGroup,
                grammarValidator: grammarValidator,
                pointsCounter: pointsCounter,
                location: location,
                abilityInventory: _abilityInventory);
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

            if (_handWordUnitsGroup.Layout.AllElementsCount == 0)
                _presenter.DrawWords();

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