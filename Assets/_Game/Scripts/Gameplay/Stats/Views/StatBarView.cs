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

        private float _current;
        private bool _roundUp;

        public void Init(Stat stat, bool roundUp = true)
        {
            _roundUp = roundUp;

            _current = stat.CurrentValue;
            UpdateView(stat.CurrentValue, stat.Max);

            stat.Current.Subscribe(current => 
            {
                if (_delayedBar != null)
                {
                    _progressBar.fillAmount = current / stat.Max;
                    UpdateBar(_delayedBar, current, stat.Max, Ease.OutQuad);
                }
                else
                {
                    UpdateBar(_progressBar, current, stat.Max, Ease.OutCubic);
                }
            });
        }

        private void UpdateBar(Image bar, float end, float max, Ease ease)
        {
            var endValue = end;
            DOTween.To(
                () => _current,
                c =>
                {
                    _current = c;
                    bar.fillAmount = _current / max;
                    UpdateView(_current, max);
                },
                endValue,
                0.75f
            ).SetEase(ease);
        }

        private void UpdateView(float current, float max)
        {
            if (_roundUp)
            {
                current = Mathf.FloorToInt(current);
                max = Mathf.FloorToInt(max);
            }

            if (_onlyCurrent)
                _valueView.text = $"{current}";
            else
                _valueView.text = $"{current}/{max}";
        }
    }
}