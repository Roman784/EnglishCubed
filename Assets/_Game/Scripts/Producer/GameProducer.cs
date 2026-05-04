using GameRoot;
using UnityEngine;

namespace GameProducer
{
    public class GameProducer
    {
        public GameProducerContext Context { get; private set; }

        public readonly EncounterProducer Encounter;
        public readonly EnemyProducer Enemy;
        public readonly WordUnitsProducer WordUnits;
        public readonly CurrencyProducer Currency;

        public GameProducer()
        {
            Context = new GameProducerContext();

            Encounter = new EncounterProducer(Context);
            Enemy = new EnemyProducer(Context);
            WordUnits = new WordUnitsProducer(Context);
            Currency = new CurrencyProducer(Context);
        }
    }
}