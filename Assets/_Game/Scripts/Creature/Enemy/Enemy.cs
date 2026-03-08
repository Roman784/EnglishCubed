using UnityEngine;

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

            _health = new Health(100);
            _healthView.Init(_health);
        }

        public override void TakeDamage(int damage)
        {
            _health.Subtract(damage);

            if (_health.CurrentValue <= 0)
                _animator.PlayDeath();
        }
    }
}