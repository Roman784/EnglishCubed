using R3;
using UnityEngine;

namespace Gameplay
{
    public abstract class Creature : MonoBehaviour
    {
        [SerializeField] protected CreatureAnimator _animator;

        protected bool _isAlive;

        public bool IsAlive => _isAlive;
        public Observable<Unit> OnAttackEvent => _animator.OnAttackEvent;

        public virtual void Init()
        {
            _isAlive = true;
        }

        protected void Kill()
        {
            if (!_isAlive) return;
            _isAlive = false;

            _animator.PlayDeath();
        }
    }
}