using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using R3;

namespace Utils
{
    public class MoveOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _position = new Vector3(0f, 1.5f, 0f);
        [SerializeField] private float _duration = 0.15f;
        [SerializeField] private Ease _ease = Ease.OutQuad;

        private PointerDetector _pointerDetector;
        private Vector3 _initialPosition;
        private Tween _currentTween;

        private void Awake()
        {
            _initialPosition = _target.localPosition;

            if (TryGetComponent<PointerDetector>(out var pointerDetector))
            {
                _pointerDetector = pointerDetector;
                _pointerDetector.OnPointerEnterSignal.Subscribe(_ => MoveIn());
                _pointerDetector.OnPointerExitSignal.Subscribe(_ => MoveOut());
            }
        }

        private void OnValidate()
        {
            if (_target == null)
                _target = transform;
        }

        private void OnDisable()
        {
            _target.localPosition = _initialPosition;
            _currentTween?.Kill();
        }

        private void Update()
        {
#if (UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
            if (UnityEngine.Device.Application.isMobilePlatform && 
                Input.touchCount == 0 && _target.localPosition != _initialPosition)
            {
                MoveOut();
            }
#endif
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_pointerDetector != null) return;
            MoveIn();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_pointerDetector != null) return;
            MoveOut();
        }

        public void MoveIn()
        {
            _currentTween?.Kill();
            _currentTween = _target.DOLocalMove(_position, _duration).SetEase(_ease);
        }

        public void MoveOut()
        {
            _currentTween?.Kill();
            _currentTween = _target.DOLocalMove(_initialPosition, _duration).SetEase(_ease);
        }
    }
}