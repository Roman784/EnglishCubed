using GameRoot;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(HeroAnimator))]
    public class Hero : MonoBehaviour
    {
        private HeroAnimator _animator;

        public HeroAnimator Animator => _animator;
        private HeroStats Stats => G.HeroStats;

        private void Awake()
        {
            _animator = GetComponent<HeroAnimator>();
        }

        public void TakeDamage()
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