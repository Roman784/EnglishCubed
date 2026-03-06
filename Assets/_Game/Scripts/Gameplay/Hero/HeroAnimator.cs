using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class HeroAnimator : MonoBehaviour
    {
        public enum AnimationState
        {
            None,
            Idle,
            Attack,
            Death
        }

        [SerializeField] private Animator _animator;

        private Dictionary<AnimationState, string> _animationsMap = new();

        private void Awake()
        {
            _animationsMap[AnimationState.Idle] = "Idle";
            _animationsMap[AnimationState.Attack] = "Attack";
            _animationsMap[AnimationState.Death] = "Death";
        }

        public void PlayAttack()
        {
            SetState(AnimationState.Attack);
        }

        private void SetState(AnimationState state, float mixDuration = 0.2f)
        {
            if (_animationsMap.TryGetValue(state, out var name))
            {
                _animator.CrossFade(name, mixDuration);
            }
        }
    }
}