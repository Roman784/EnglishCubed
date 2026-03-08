using R3;
using UnityEngine;

namespace Gameplay
{
    public abstract class Creature : MonoBehaviour
    {
        [SerializeField] protected CreatureAnimator _animator;

        public CreatureAnimator Animator => _animator;

        public Observable<Unit> OnAttackEvent => _animator.OnAttackEvent;

        public virtual void Init()
        {
        }

        public abstract void TakeDamage(int damage);
    }
}