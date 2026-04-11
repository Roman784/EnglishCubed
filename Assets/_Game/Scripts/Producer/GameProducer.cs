using GameRoot;
using UnityEngine;

namespace GameProducer
{
    public class GameProducer
    {
        public GameProducerContext Context { get; private set; }

        public readonly EnemyProducer Enemy;

        public GameProducer()
        {
            Context = new GameProducerContext();

            Enemy = new EnemyProducer(Context);
        }
    }
}