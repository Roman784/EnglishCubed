using DG.Tweening;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitBackplate : MonoBehaviour, ILayoutElement
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _view;

        private Tween _movingTween;
        private Tween _localViewMovingTween;

        public Transform Transform => transform;
        public Vector2 Position => transform.position;
        public Vector2 ContainerSize => _container.sizeDelta;

        private void Awake()
        {
            _canvasGroup.alpha = 1f;
        }

        public void SetSize(Vector2 size)
        {
            _container.sizeDelta = size;
        }

        public Tween MoveTo(Vector2 to)
        {
            _movingTween?.Kill();
            _movingTween = transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _movingTween;
        }

        public Tween MoveToByDecreasing(Vector2 position)
        {
            return null;
        }

        public Tween MoveViewToLocal(Vector2 to)
        {
            _localViewMovingTween?.Kill();
            _localViewMovingTween = _view.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _localViewMovingTween;
        }

        public void Destroy()
        {
            _canvasGroup.DOFade(0, 0.1f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}