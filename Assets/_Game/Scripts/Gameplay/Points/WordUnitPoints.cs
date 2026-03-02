using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitPoints : MonoBehaviour
    {
        [SerializeField] private Transform _rootView;
        [SerializeField] private TMP_Text _valueView;

        private int _value;
        private char _sign;

        private Sequence _shakeSeq;

        public int Value => _value;
        public char Sign => _sign;

        public void Plus(int value)
        {
            _value += value;
            UpdateView();
        }

        public void SetSign(char sign)
        {
            _sign = sign;
            UpdateView();
        }

        public void Show()
        {
            _rootView.localScale = Vector2.one * 0.5f;
            _rootView.localPosition = new Vector2(0, -0.5f);

            _rootView.DOScale(1, 0.2f).SetEase(Ease.OutBack);
            _rootView.DOLocalMoveY(0, 0.1f).SetEase(Ease.OutBack);
        }

        public void TurnIntoAccumulator()
        {
            _valueView.text = _value.ToString();
            transform.DOScale(1.25f, 0.25f).SetEase(Ease.OutBack);
        }

        public Tween MoveToAccumulator(Vector2 position, bool doFade = true)
        {
            var seq = DOTween.Sequence();

            seq.Join(transform.DOMove(position, 0.5f).SetEase(Ease.InBack));

            if (doFade)
            {
                seq.AppendInterval(0.25f);
                seq.Join(_valueView.DOFade(0, 0.25f).SetEase(Ease.OutCirc));
            }

            return seq;
        }

        public void Shake()
        {
            _shakeSeq?.Kill(true);
            _shakeSeq = DOTween.Sequence();

            //_shakeSeq.Join(_rootView.DOShakeRotation(0.25f, new Vector3(15, 30, 30)));
            _shakeSeq.Join(_rootView.DOShakeScale(0.5f, 1.5f, 10, 0));
        }

        private void UpdateView()
        {
            _valueView.text = $"{_sign}{_value}";
        }
    }
}