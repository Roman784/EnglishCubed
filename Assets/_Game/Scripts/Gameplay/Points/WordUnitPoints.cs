using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Gameplay
{
    public class WordUnitPoints : MonoBehaviour
    {
        [SerializeField] private Transform _rootView;
        [SerializeField] private TMP_Text _valueView;

        private int _value;
        private string _sign;

        private Sequence _popSeq;

        public int Value => _value;
        public string Sign => _sign;

        public void Plus(int value)
        {
            _value += value;
            UpdateView();
        }

        public void SetSign(string sign)
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
            _sign = "<sprite index=1>";
            UpdateView();

            transform.DOScale(1.5f, 0.25f).SetEase(Ease.OutBack);
        }

        public Tween SendToAccumulator()
        {
            var seq = DOTween.Sequence();
            seq.Append(_rootView.DOLocalMoveY(0.2f, 0.15f).SetEase(Ease.OutCubic));
            seq.AppendInterval(0.25f);
            seq.Append(_rootView.DOLocalMoveY(0, 0.15f).SetEase(Ease.Flash));
            seq.Join(_valueView.DOFade(0, 0.15f).SetEase(Ease.InQuad));

            return seq;
        }

        public Tween MoveToAccumulator(Vector2 position)
        {
            var seq = DOTween.Sequence();
            seq.Join(transform.DOMove(position, 0.5f).SetEase(Ease.InBack));

            return seq;
        }

        public void Pop()
        {
            _popSeq?.Kill(true);
            _popSeq = DOTween.Sequence();

            _popSeq.Join(_rootView.DOScale(1.25f, 0.15f).SetEase(Ease.OutBack));
            _popSeq.Append(_rootView.DOScale(1f, 0.25f).SetEase(Ease.OutQuad));
        }

        private void UpdateView()
        {
            _valueView.text = $"{_sign}{_value}";
        }
    }
}