using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class Health : Stat
    {
        public Health(int max) : base(max, max)
        {
        }

        public Health(int current, int max) : base(current, max)
        {
        }

        public override void IncreaseOne()
        {
            G.CameraShaker.WeakShake();
            base.IncreaseOne();
        }
    }
}