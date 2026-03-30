using R3;
using UnityEngine;

namespace Gameplay
{
    public abstract class Creature : MonoBehaviour
    {
        [SerializeField] protected CreatureAnimator _animator;

        protected Stats _stats;
        private Subject<Unit> _deathSignalSubj = new();

        public bool IsAlive => _stats.Health.IsAlive;
        public Stats Stats => _stats;
        public Observable<Unit> OnAttackEvent => _animator.OnAttackEvent;
        public Observable<Unit> DeathSignal => _deathSignalSubj;

        public virtual void Init(Stats stats)
        {
            _stats = stats;
        }

        protected void Kill()
        {
            if (IsAlive)
            {
                _stats.Health.SetToZero();
                return;
            }

            _animator.PlayDeath();

            _deathSignalSubj.OnNext(Unit.Default);
            _deathSignalSubj.OnCompleted();
        }
    }
}