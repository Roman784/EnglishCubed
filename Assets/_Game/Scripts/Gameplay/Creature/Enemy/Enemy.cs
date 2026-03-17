using UnityEngine;
using R3;

namespace Gameplay
{
    public class Enemy : Creature
    {
        [SerializeField] private StatBarView _healthView;
        [SerializeField] private Transform _centerPoint;

        private Health _health;

        public Vector2 Center => _centerPoint.position;
        public int CurrentHealth => _health.CurrentValue;

        public override void Init()
        {
            base.Init();

            _health = new Health(200);
            _healthView.Init(_health);

            _health.ZeroReachedSignal.Subscribe(_ => Kill());
        }

        public Observable<Unit> Attack()
        {
            _animator.PlayAttack();
            return _animator.OnAttackEvent;
        }

        public void TakeDamage(int damage, out float animationDuration)
        {
            if (!_isAlive)
            {
                animationDuration = 0;
                return;
            }

            _health.Subtract(damage);
            animationDuration = CurrentHealth > 0 ? 
                _animator.PlayDamage() : _animator.GetDeathLength();
        }
    }
}