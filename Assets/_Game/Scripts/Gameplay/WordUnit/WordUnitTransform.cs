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

        [Space]

        [SerializeField] private float _containerBorderWidth;
        [SerializeField] private float _minContainerWidth;

        public Transform Transform => transform;
        public Vector2 Position => Transform.position;
        public Vector2 ContainerSize => _containerView.sizeDelta;

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
            return _rootView.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
        }
    }
}