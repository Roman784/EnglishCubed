using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class Hero : Creature
    {
        public new HeroAnimator Animator => (HeroAnimator)_animator;
        public int CurrentHealth => G.HeroStats.Health.CurrentValue;
        private HeroStats Stats => G.HeroStats;

        public override void Init()
        {
        }

        public override void TakeDamage(int _=0)
        {
            if (Stats.Armor.CurrentValue > 0)
                Stats.Armor.DecreaseOne();
            else if (Stats.Health.CurrentValue > 0)
                Stats.Health.DecreaseOne();

            if (Stats.Health.CurrentValue <= 0) return;

            _animator.PlayDamage();
            G.CameraShaker.WeakShake();
        }

        private void Die()
        {

        }
    }
}