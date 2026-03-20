using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class Health : Stat
    {
        public Health(int max) : base(StatName.Health, max, max)
        {
        }

        public Health(int current, int max) : base(StatName.Health, current, max)
        {
        }

        public void Restore(int value)
        {
            Add(value);
        }
    }
}