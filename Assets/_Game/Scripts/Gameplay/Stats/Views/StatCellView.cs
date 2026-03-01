using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class StatCellView: MonoBehaviour
    {
        [SerializeField] private Image _fullView;

        private bool _isSpent;

        [ContextMenu("Spend")]
        public void Spend()
        {
            if (_isSpent) return;
            _isSpent = true;

            _fullView.transform.DOScale(1.5f, 1f).SetEase(Ease.OutQuad);
            _fullView.DOFade(0f, 1f);
        }

        [ContextMenu("Fill")]
        public void Fill()
        {
            if (!_isSpent) return;
            _isSpent = false;

            _fullView.transform.localScale = Vector3.zero;
            _fullView.transform.DOScale(1f, 1f).SetEase(Ease.OutBack);
            _fullView.DOFade(1f, 1f).SetEase(Ease.OutQuad);
        }
    }
}