using Abilities;
using Configs;
using Gameplay;
using GrammarValidation;
using R3;

namespace Combat
{
    public class CombatModel
    {
        private Subject<Unit> _changedSignalSubj = new();

        public Hero Hero { get; private set; }
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
        public WordUnitConfigs[] AvailableWordUnitsConfigs { get; private set; }

        public Stats HeroStats => Hero.Stats;
        public int AvailableWordsOnFieldCount => (int)FieldCapacity.Max - UnitsOnFieldCount;
        public int UnitsOnFieldCount => FieldWordUnitsGroup.AllElementsCount;
        public int UnitsInHandCount => HandWordUnitsGroup.AllElementsCount;

        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public CombatModel(
            Hero hero,
            PointMultipliersResolver pointMultiplierResolver,
            Deck deck,
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup,
            GrammarValidator grammarValidator,
            PointsCounter pointsCounter,
            Location location,
            AbilityInventoryPresenter abilityInventory,
            WordUnitConfigs[] availableWordUnitsConfigs)
        {
            Hero = hero;
            Discards = HeroStats.GetStat(StatName.DiscardsCount);
            Draws = HeroStats.GetStat(StatName.DrawsCount);
            FieldCapacity = HeroStats.GetStat(StatName.FieldCapacity);
            HandCapacity = HeroStats.GetStat(StatName.HandCapacity);

            PointMultiplierResolver = pointMultiplierResolver;
            Deck = deck;
            HandWordUnitsGroup = handWordUnitsGroup;
            FieldWordUnitsGroup = fieldWordUnitsGroup;
            GrammarValidator = grammarValidator;
            PointsCounter = pointsCounter;
            Location = location;

            AbilityInventory = abilityInventory;
            AvailableWordUnitsConfigs = availableWordUnitsConfigs;

            HandWordUnitsGroup.Init();
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
    }
}