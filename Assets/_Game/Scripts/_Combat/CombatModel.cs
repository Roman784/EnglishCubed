using Abilities;
using Configs;
using EncountersMap;
using Gameplay;
using GameRoot;
using GrammarValidation;
using R3;

namespace Combat
{
    public class CombatModel
    {
        private Subject<Unit> _changedSignalSubj = new();

        public LevelConfigs LevelConfigs { get; private set; }
        public CombatEnterParams EnterParams { get; private set; }

        public Hero Hero { get; private set; }
        public Enemy Enemy { get; private set; }

        public Stat Discards { get; private set; }
        public Stat Draws { get; private set; }
        public Stat FieldCapacity { get; private set; }
        public Stat HandCapacity { get; private set; }
        public PointMultipliersResolver PointMultiplierResolver { get; private set; }

        public Deck Deck { get; private set; }
        public HandWordUnitsGroup HandWordUnitsGroup { get; private set; }
        public FieldWordUnitsGroup FieldWordUnitsGroup { get; private set; }
        public GrammarValidator GrammarValidator { get; private set; }
        public PointsCounter PointsCounter { get; private set; }
        public Location Location { get; private set; }

        public AbilityInventoryPresenter AbilityInventory { get; private set; }

        public Stats HeroStats => Hero.Stats;
        public int AvailableWordsOnFieldCount => (int)FieldCapacity.Max - UnitsOnFieldCount;
        public int UnitsOnFieldCount => FieldWordUnitsGroup.AllElementsCount;
        public int UnitsInHandCount => HandWordUnitsGroup.AllElementsCount;
        public bool IsBossEncounter => EnterParams.EncounterName == EncounterName.BossCombat;

        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public CombatModel(
            LevelConfigs levelConfigs,
            CombatEnterParams enterParams,
            Hero hero,
            Enemy enemy,
            PointMultipliersResolver pointMultiplierResolver,
            Deck deck,
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup,
            GrammarValidator grammarValidator,
            PointsCounter pointsCounter,
            Location location,
            AbilityInventoryPresenter abilityInventory)
        {
            LevelConfigs = levelConfigs;
            EnterParams = enterParams;

            Hero = hero;
            Enemy = enemy;

            Discards = HeroStats.GetStatOrCreateNew(StatName.DiscardsCount);
            Draws = HeroStats.GetStatOrCreateNew(StatName.DrawsCount);
            FieldCapacity = HeroStats.GetStatOrCreateNew(StatName.FieldCapacity);
            HandCapacity = HeroStats.GetStatOrCreateNew(StatName.HandCapacity);

            PointMultiplierResolver = pointMultiplierResolver;
            Deck = deck;
            HandWordUnitsGroup = handWordUnitsGroup;
            FieldWordUnitsGroup = fieldWordUnitsGroup;
            GrammarValidator = grammarValidator;
            PointsCounter = pointsCounter;
            Location = location;

            AbilityInventory = abilityInventory;

            FieldWordUnitsGroup.SetMaxAvailableWordsCount((int)FieldCapacity.Max);

            Discards.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            Draws.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            FieldCapacity.Current.Subscribe(_ => 
            { 
                FieldWordUnitsGroup.SetMaxAvailableWordsCount((int)FieldCapacity.Max);
                _changedSignalSubj.OnNext(Unit.Default);
            });
            HandCapacity.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            HandWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            FieldWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
        }

        public void RestoreArmor()
        {
            Hero.Stats.Armor.RestoreFull();
        }

        public void RestoreDiscards()
        {
            Discards.RestoreFull();
        }

        public void RestoreDraws()
        {
            Draws.RestoreFull();
        }
    }
}