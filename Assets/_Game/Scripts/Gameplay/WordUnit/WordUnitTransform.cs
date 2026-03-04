using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitTransform : MonoBehaviour, ILayoutElement
    {
        [SerializeField] private Transform _rootView;
        [SerializeField] private RectTransform _containerView;
        [SerializeField] private CanvasGroup _canvasGroup;

        [Space]

        [SerializeField] private float _containerBorderWidth;
        [SerializeField] private float _minContainerWidth;

        private Tween _movingTween;
        private Tween _localViewMovingTween;
        private Sequence _movingWithDecreasingSeq;
        private Sequence _discardingSeq;

        public Transform Transform => transform;
        public Vector2 Position => Transform.position;
        public Vector2 ContainerSize => _containerView.sizeDelta;

        private void Awake()
        {
            _canvasGroup.alpha = 1f;
        }

        public void SetContainerSize(float wordWidth)
        {
            var containerHeight = _containerView.sizeDelta.y;
            var newContainerWidth = wordWidth + _containerBorderWidth * 2f;
            newContainerWidth = Mathf.Max(_minContainerWidth, newContainerWidth);
            _containerView.sizeDelta = new Vector2(newContainerWidth, containerHeight);
        }

        public Tween MoveTo(Vector2 to)
        {
            _movingTween?.Kill();
            _movingTween = transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _movingTween;
        }

        public Tween MoveToByDecreasing(Vector2 position)
        {
            _movingWithDecreasingSeq?.Kill();
            _movingWithDecreasingSeq = DOTween.Sequence();

            _movingWithDecreasingSeq.Append(_rootView.DOScale(0, 0.15f));
            _movingWithDecreasingSeq.AppendCallback(() => transform.position = position);
            _movingWithDecreasingSeq.Append(_rootView.DOScale(1, 0.2f).SetEase(Ease.OutBack));

            return _movingWithDecreasingSeq;
        }

        public Tween MoveViewToLocal(Vector2 to)
        {
            _localViewMovingTween?.Kill();
            _localViewMovingTween = _rootView.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _localViewMovingTween;
        }

        public Tween Discard(Vector2 deckPosition)
        {
            _discardingSeq?.Kill();
            _discardingSeq = DOTween.Sequence();

            _discardingSeq.Join(transform.DOMove(deckPosition, 0.5f).SetEase(Ease.OutCubic));
            _discardingSeq.Join(_canvasGroup.DOFade(0, 0.5f).SetEase(Ease.InQuint));
            _discardingSeq.Join(transform.DOScale(0.1f, 0.5f).SetEase(Ease.InExpo));

            return _discardingSeq;
        }
    }
}