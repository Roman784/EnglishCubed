using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitPoints : MonoBehaviour
    {
        [SerializeField] private Transform _rootView;
        [SerializeField] private TMP_Text _pointsView;

        public void InitPlus(int points)
        {
            _pointsView.text = $"+{points}";
            Show();
        }

        private void Show()
        {
            _rootView.localScale = Vector2.one * 0.5f;
            _rootView.localPosition = new Vector2(0, -0.5f);

            _rootView.DOScale(1, 0.2f).SetEase(Ease.OutBack);
            _rootView.DOLocalMoveY(0, 0.1f).SetEase(Ease.OutBack);
        }
    }
}