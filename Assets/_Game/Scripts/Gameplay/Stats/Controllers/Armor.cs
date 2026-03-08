using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class Armor: Stat
    {
        public Armor(int max) : base(max, max)
        { 
        }

        public Armor(int current, int max) : base(current, max)
        {
        }

        public override void IncreaseOne()
        {
            G.CameraShaker.WeakShake();
            base.IncreaseOne();
        }
    }
}