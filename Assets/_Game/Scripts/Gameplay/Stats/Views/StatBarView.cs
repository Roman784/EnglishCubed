using UnityEngine;
using R3;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Gameplay
{
    public class StatBarView : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _valueView;

        private int _current;

        public void Init(Stat stat)
        {
            stat.Current.Subscribe(current => UpdateProgress(current, stat.Max));
        }

        private void UpdateProgress(int end, int max)
        {
            var endValue = end;
            DOTween.To(
                () => _current,
                c =>
                {
                    _current = c;
                    _progressBar.fillAmount = (float)_current / max;
                    _valueView.text = $"{(int)_current}/{max}";
                },
                endValue,
                0.75f
            ).SetEase(Ease.OutCubic);
        }
    }
}