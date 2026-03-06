using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(HeroAnimator))]
    public class Hero : MonoBehaviour
    {
        private HeroAnimator _animator;

        public HeroAnimator Animator => _animator;

        private void Awake()
        {
            _animator = GetComponent<HeroAnimator>();
        }
    }
}