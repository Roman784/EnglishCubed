using UnityEngine;
using R3;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Gameplay
{
    public class StatBarView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueView;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _delayedBar;

        [Space]

        [SerializeField] private bool _onlyCurrent = true;

        private int _current;

        public void Init(Stat stat)
        {
            _current = stat.CurrentValue;
            UpdateView(stat.CurrentValue, stat.Max);

            stat.Current.Subscribe(current => 
            {
                if (_delayedBar != null)
                {
                    _progressBar.fillAmount = (float)current / stat.Max;
                    UpdateBar(_delayedBar, current, stat.Max, Ease.OutQuad);
                }
                else
                {
                    UpdateBar(_progressBar, current, stat.Max, Ease.OutCubic);
                }
            });
        }

        private void UpdateBar(Image bar, int end, int max, Ease ease)
        {
            var endValue = end;
            DOTween.To(
                () => _current,
                c =>
                {
                    _current = c;
                    bar.fillAmount = (float)_current / max;
                    UpdateView(_current, max);
                },
                endValue,
                0.75f
            ).SetEase(ease);
        }

        private void UpdateView(int current, int max)
        {
            if (_onlyCurrent)
                _valueView.text = $"{(int)current}";
            else
                _valueView.text = $"{(int)current}/{max}";
        }
    }
}