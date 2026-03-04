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

        private Tween _localViewMovement;

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
            return transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
        }

        public Tween MoveToByDecreasing(Vector2 position)
        {
            return null;
        }

        public Tween MoveViewToLocal(Vector2 to)
        {
            _localViewMovement?.Kill();
            _localViewMovement = _view.DOLocalMove(to, 0.25f).SetEase(Ease.OutQuad);
            return _localViewMovement;
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