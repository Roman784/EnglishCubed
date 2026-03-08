using R3;
using UnityEngine;

namespace Gameplay
{
    public abstract class Creature : MonoBehaviour
    {
        [SerializeField] protected CreatureAnimator _animator;

        protected bool _isAlive;

        public CreatureAnimator Animator => _animator;
        public Observable<Unit> OnAttackEvent => _animator.OnAttackEvent;

        public virtual void Init()
        {
            _isAlive = true;
        }

        public abstract void TakeDamage(int damage);

        protected void Die()
        {
            if (!_isAlive) return;
            _isAlive = false;

            _animator.PlayDeath();
        }
    }
}