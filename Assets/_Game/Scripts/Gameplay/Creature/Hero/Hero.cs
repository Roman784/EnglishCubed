using GameRoot;
using UnityEngine;
using R3;
using System;

namespace Gameplay
{
    public class Hero : Creature
    {
        public bool IsMoreThanOneHealthUnit => _stats.Health.CurrentValue > 1;

        public override void Init(Stats stats)
        {
            base.Init(stats);

            _stats.Health.ZeroReachedSignal.Subscribe(_ => Kill());
        }

        public void Attack()
        {
            _animator.PlayAttack();
        }

        public void TakeDamage()
        {
            if (!IsAlive) return;

            G.CameraShaker.WeakShake();

            if (_stats.Armor.CurrentValue > 0)
                _stats.Armor.DecreaseOne();
            else if (_stats.Health.CurrentValue > 0)
                _stats.Health.DecreaseOne();

            if (IsAlive)
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