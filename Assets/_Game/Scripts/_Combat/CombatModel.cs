using Gameplay;
using GrammarValidation;
using R3;

namespace Combat
{
    public class CombatModel
    {
        private Subject<Unit> _changedSignalSubj = new();

        public int DiscardPoints { get; private set; }
        public int DrawPoints { get; private set; }
        public int MaxAvailableWordsOnFieldCount { get; private set; }
        public int MaxHandCapacity { get; private set; }

        public Deck Deck { get; private set; }
        public HandWordUnitsGroup HandWordUnitsGroup { get; private set; }
        public FieldWordUnitsGroup FieldWordUnitsGroup { get; private set; }
        public GrammarValidator GrammarValidator { get; private set; }
        public PointsCounter PointsCounter { get; private set; }
        public Location Location { get; private set; }

        public Hero Hero => Location.Hero;
        public int AvailableWordsOnFieldCount => MaxAvailableWordsOnFieldCount - UnitsOnFieldCount;
        public int UnitsOnFieldCount => FieldWordUnitsGroup.AllElementsCount;
        public int UnitsInHandCount => HandWordUnitsGroup.AllElementsCount;

        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public CombatModel(
            int discardPoints, 
            int drawPoints,
            int maxAvailableWordsOnFieldCount,
            int maxHandCapacity,
            Deck deck,
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup,
            GrammarValidator grammarValidator,
            PointsCounter pointsCounter,
            Location location)
        {
            DiscardPoints = discardPoints;
            DrawPoints = drawPoints;
            MaxAvailableWordsOnFieldCount = maxAvailableWordsOnFieldCount;
            MaxHandCapacity = maxHandCapacity;
            Deck = deck;
            HandWordUnitsGroup = handWordUnitsGroup;
            FieldWordUnitsGroup = fieldWordUnitsGroup;
            GrammarValidator = grammarValidator;
            PointsCounter = pointsCounter;
            Location = location;

            HandWordUnitsGroup.Init();
            FieldWordUnitsGroup.Init(maxAvailableWordsOnFieldCount);

            HandWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
            FieldWordUnitsGroup.ChangedSignal.Subscribe(_ => _changedSignalSubj.OnNext(Unit.Default));
        }

        public void SpendDiscardPoint()
        {
            DiscardPoints--;
            _changedSignalSubj.OnNext(Unit.Default);
        }

        public void SpendDrawPoint()
        {
            DrawPoints--;
            _changedSignalSubj.OnNext(Unit.Default);
        }
    }
}