using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class GameplayProducer
    {
        public ProducerContext Context { get; private set; }

        public readonly EnemyProducer Enemy;

        public GameplayProducer()
        {
            Context = new ProducerContext();

            Enemy = new EnemyProducer(Context);
        }
    }
}