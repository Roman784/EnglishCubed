using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private Transform _camera;

        private Tween _shakeTween;

        public void WeakShake()
        {
            Shake(0.1f, 1);
        }

        public void MidShake()
        {
            Shake(0.5f, 3);
        }

        public void StrongShake()
        {
            Shake(1f, 4);
        }

        public void Shake(float strengh, int vibrato = 3)
        {
            _shakeTween?.Kill();
            _shakeTween = _camera.DOShakePosition(0.2f, strengh, vibrato, 45)
                .SetEase(Ease.OutQuad);
        }
    }
}