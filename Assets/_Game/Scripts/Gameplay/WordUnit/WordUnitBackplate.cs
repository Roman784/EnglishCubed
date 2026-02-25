using DG.Tweening;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitBackplate : MonoBehaviour, ILayoutElement
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _view;

        public Transform Transform => transform;
        public Vector2 Position => transform.position;
        public Vector2 ContainerSize => _container.sizeDelta;


        public void SetSize(Vector2 size)
        {
            _container.sizeDelta = size;
        }

        public Tween MoveTo(Vector2 to)
        {
            return transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
        }

        public Tween MoveToByDecreasing(Vector2 position)
        {
            return null;
        }

        public Tween MoveViewToLocal(Vector2 to)
        {
            return _view.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
        }
    }
}