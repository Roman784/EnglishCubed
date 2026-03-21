using UnityEngine;
using R3;

namespace Gameplay
{
    public class Enemy : Creature
    {
        [SerializeField] private StatBarView _healthView;
        [SerializeField] private Transform _centerPoint;

        private Stats _stats;

        public Vector2 Center => _centerPoint.position;
        public float CurrentHealth => _stats.Health.CurrentValue;

        public override void Init()
        {
            base.Init();

            var health = new Health(2000);
            _healthView.Init(health);

            _stats = new Stats(health);

            _stats.Health.ZeroReachedSignal.Subscribe(_ => Kill());
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

            _stats.Health.Subtract(damage);
            animationDuration = CurrentHealth > 0 ? 
                _animator.PlayDamage() : _animator.GetDeathLength();
        }
    }
}