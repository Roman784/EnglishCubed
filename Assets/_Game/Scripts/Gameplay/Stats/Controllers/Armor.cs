using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class Armor : Stat
    {
        public Armor(int max) : base(StatName.Armor, max, max)
        {
        }

        public Armor(int current, int max) : base(StatName.Armor, current, max)
        {
        }

        public void Restore(int value)
        {
            Add(value);
        }
    }
}