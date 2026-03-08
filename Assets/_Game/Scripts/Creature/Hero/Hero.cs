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

        public override void TakeDamage(int _=0)
        {
            if (!_isAlive) return;

            G.CameraShaker.WeakShake();

            if (Stats.Armor.CurrentValue > 0)
                Stats.Armor.DecreaseOne();
            else if (Stats.Health.CurrentValue > 0)
                Stats.Health.DecreaseOne();

            if (Stats.Health.CurrentValue > 0)
                _animator.PlayDamage();
        }
    }
}