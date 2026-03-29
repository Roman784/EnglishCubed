using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private RectTransform _viewport;

        private void Start()
        {
            Show();
        }

        private void Show()
        {
            _viewport.localScale = Vector2.up;
            _viewport.DOScaleX(1, 0.5f).SetEase(Ease.OutBack);
        }
    }
}