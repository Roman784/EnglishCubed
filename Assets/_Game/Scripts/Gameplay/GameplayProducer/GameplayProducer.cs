using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class GameplayProducer
    {
        public readonly EnemyProducer Enemy;

        public GameplayProducer()
        {
            Enemy = new EnemyProducer();
        }
    }
}