using R3;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public enum CreatureAnimationState
    {
        None,
        Idle,
        Attack,
        Damage,
        Death
    }

    public class CreatureAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private Subject<Unit> _onAttackEventSubj = new();

        private Dictionary<CreatureAnimationState, string> _animationsMap = new();

        public Observable<Unit> OnAttackEvent => _onAttackEventSubj;

        private void Awake()
        {
            _animationsMap[CreatureAnimationState.Idle] = "Idle";
            _animationsMap[CreatureAnimationState.Attack] = "Attack";
            _animationsMap[CreatureAnimationState.Damage] = "Damage";
            _animationsMap[CreatureAnimationState.Death] = "Death";
        }

        public void OnAttack()
        {
            _onAttackEventSubj.OnNext(Unit.Default);
            _onAttackEventSubj = new Subject<Unit>();
        }

        public float PlayIdle() => SetState(CreatureAnimationState.Idle);
        public float PlayAttack() => SetState(CreatureAnimationState.Attack);
        public float PlayDamage() => SetState(CreatureAnimationState.Damage, 0);
        public float PlayDeath() => SetState(CreatureAnimationState.Death);

        public float GetDeathLength() => GetAnimationLength(CreatureAnimationState.Death);

        protected float SetState(CreatureAnimationState state, float mixDuration = 0.2f)
        {
            if (_animationsMap.TryGetValue(state, out var name))
            {
                _animator.CrossFade(name, mixDuration);
                return GetAnimationLength(state);
            }

            return 0f;
        }

        private float GetAnimationLength(CreatureAnimationState state)
        {
            if (_animationsMap.TryGetValue(state, out var name))
            {
                var clips = _animator.runtimeAnimatorController.animationClips;
                foreach (AnimationClip clip in clips)
                {
                    if (clip.name == name)
                        return clip.length;
                }
            }
            return 0f;
        }
    }
}