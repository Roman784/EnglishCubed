using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using R3;

namespace Utils
{
    public class ZoomOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _zoomScale = 1.2f;
        [SerializeField] private float _duration = 0.15f;
        [SerializeField] private Ease _ease = Ease.OutQuad;

        private PointerDetector _pointerDetector;
        private Vector3 _initialScale;
        private Tween _currentTween;

        private void Awake()
        {
            _initialScale = _target.localScale;

            if (TryGetComponent<PointerDetector>(out var pointerDetector))
            {
                _pointerDetector = pointerDetector;
                _pointerDetector.OnPointerEnterSignal.Subscribe(_ => ZoomIn());
                _pointerDetector.OnPointerExitSignal.Subscribe(_ => ZoomOut());
            }
        }

        private void OnValidate()
        {
            if (_target == null)
                _target = transform;
        }

        private void OnDisable()
        {
            _target.localScale = _initialScale;
            _currentTween?.Kill();
        }

        private void Update()
        {
#if (UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
            if (UnityEngine.Device.Application.isMobilePlatform && 
                Input.touchCount == 0 && _target.localScale != _initialScale)
            {
                ZoomOut();
            }
#endif
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_pointerDetector != null) return;
            ZoomIn();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_pointerDetector != null) return;
            ZoomOut();
        }

        public void ZoomIn()
        {
            _currentTween?.Kill();
            _currentTween = _target.DOScale(_initialScale * _zoomScale, _duration).SetEase(_ease);
        }

        public void ZoomOut()
        {
            _currentTween?.Kill();
            _currentTween = _target.DOScale(_initialScale, _duration).SetEase(_ease);
        }
    }
}