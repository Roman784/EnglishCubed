using UnityEngine;
using R3;
using GameRoot;

namespace Gameplay
{
    public class Enemy : Creature
    {
        [SerializeField] private StatBarView _healthView;
        [SerializeField] private Transform _centerPoint;

        public Vector2 Center => _centerPoint.position;
        public float CurrentHealth => _stats.Health.CurrentValue;

        public override void Init(Stats stats)
        {
            base.Init(stats);

            _healthView.Init(stats.Health);

            _stats.Health.ZeroReachedSignal.Subscribe(_ => Kill());
        }

        public Observable<Unit> Attack()
        {
            _animator.PlayAttack();
            return _animator.OnAttackEvent;
        }

        public void TakeDamage(int damage, out float animationDuration)
        {
            G.AudioProvider.PlaySound(R.Audio.EnemyDamage);

            if (!IsAlive)
            {
                animationDuration = 0;
                return;
            }

            _stats.Health.Subtract(damage);
            animationDuration = CurrentHealth > 0 ? 
                _animator.PlayDamage() : _animator.GetDeathLength();
        }
    }
}