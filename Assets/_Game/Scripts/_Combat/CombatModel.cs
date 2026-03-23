using Gameplay;
using GrammarValidation;
using R3;

namespace Combat
{
    public class CombatModel
    {
        private Subject<Unit> _changedSignalSubj = new();

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

        public Hero Hero => Location.Hero;
        public int AvailableWordsOnFieldCount => (int)FieldCapacity.Max - UnitsOnFieldCount;
        public int UnitsOnFieldCount => FieldWordUnitsGroup.AllElementsCount;
        public int UnitsInHandCount => HandWordUnitsGroup.AllElementsCount;

        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public CombatModel(
            Stat discards, 
            Stat draws,
            Stat fieldCapacity,
            Stat handCapacity,
            PointMultipliersResolver pointMultiplierResolver,
            Deck deck,
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup,
            GrammarValidator grammarValidator,
            PointsCounter pointsCounter,
            Location location)
        {
            Discards = discards;
            Draws = draws;
            FieldCapacity = fieldCapacity;
            HandCapacity = handCapacity;
            PointMultiplierResolver = pointMultiplierResolver;
            Deck = deck;
            HandWordUnitsGroup = handWordUnitsGroup;
            FieldWordUnitsGroup = fieldWordUnitsGroup;
            GrammarValidator = grammarValidator;
            PointsCounter = pointsCounter;
            Location = location;

            HandWordUnitsGroup.Init();
            FieldWordUnitsGroup.SetMaxAvailableWordsCount((int)fieldCapacity.Max);

            Discards.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            Draws.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            FieldCapacity.Current.Subscribe(_ => 
            { 
                FieldWordUnitsGroup.SetMaxAvailableWordsCount((int)fieldCapacity.Max);
                _changedSignalSubj.OnNext(Unit.Default);
            });
            HandCapacity.Current.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            HandWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            FieldWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
        }
    }
}