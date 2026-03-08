using GameRoot;
using UnityEngine;
using R3;

namespace Gameplay
{
    public class Hero : Creature
    {
        private HeroStats _stats;

        public HeroStats Stats => _stats;
        public int CurrentHealth => _stats.Health.CurrentValue;

        public void Init(HeroStats stats)
        {
            base.Init();
            _stats = stats;

            _stats.Health.ZeroReachedSignal.Subscribe(_ => Die());
        }

        public override void TakeDamage(int _, out float animationDuration)
        {
            if (!_isAlive)
            {
                animationDuration = 0f;
                return;
            }

            G.CameraShaker.WeakShake();

            if (Stats.Armor.CurrentValue > 0)
                Stats.Armor.DecreaseOne();
            else if (Stats.Health.CurrentValue > 0)
                Stats.Health.DecreaseOne();

            animationDuration = CurrentHealth > 0 ?
                _animator.PlayDamage() : _animator.GetDeathLength();
        }
    }
}