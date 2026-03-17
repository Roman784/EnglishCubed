using GameRoot;
using UnityEngine;
using R3;

namespace Gameplay
{
    public class Hero : Creature
    {
        private HeroStats _stats;

        public bool IsMoreThanOneHealthUnit => _stats.Health.CurrentValue > 1;

        public void Init(HeroStats stats)
        {
            base.Init();

            _stats = stats;

            _stats.Health.ZeroReachedSignal.Subscribe(_ => Kill());
        }

        public void Attack()
        {
            _animator.PlayAttack();
        }

        public void TakeDamage()
        {
            if (!_isAlive) return;

            G.CameraShaker.WeakShake();

            if (_stats.Armor.CurrentValue > 0)
                _stats.Armor.DecreaseOne();
            else if (_stats.Health.CurrentValue > 0)
                _stats.Health.DecreaseOne();

            if (_isAlive) 
                _animator.PlayDamage();
        }

        public void SubstractOneHealthUnit()
        {
            G.CameraShaker.WeakShake();
            _stats.Health.DecreaseOne();
        }

        public void AddExperience(int value)
        {
            _stats.Experience.Add(value);
        }
    }
}