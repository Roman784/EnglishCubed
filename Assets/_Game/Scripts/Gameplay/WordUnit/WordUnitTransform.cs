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

        private Tween _localViewMovement;

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
            return transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
        }

        public Tween MoveToByDecreasing(Vector2 position)
        {
            var seq = DOTween.Sequence();

            seq.Append(_rootView.DOScale(0, 0.15f));
            seq.AppendCallback(() => transform.position = position);
            seq.Append(_rootView.DOScale(1, 0.2f).SetEase(Ease.OutBack));

            return seq;
        }

        public Tween MoveViewToLocal(Vector2 to)
        {
            _localViewMovement?.Kill();
            _localViewMovement = _rootView.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _localViewMovement;
        }

        public Tween Discard(Vector2 deckPosition)
        {
            var seq = DOTween.Sequence();
            seq.Join(transform.DOMove(deckPosition, 0.5f).SetEase(Ease.OutCubic));
            seq.Join(_canvasGroup.DOFade(0, 0.5f).SetEase(Ease.InQuint));
            seq.Join(transform.DOScale(0.1f, 0.5f).SetEase(Ease.InExpo));

            return seq;
        }
    }
}