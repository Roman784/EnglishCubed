using DG.Tweening;
using GameRoot;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Gameplay
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private Transform _rootView;
        [SerializeField] private TMP_Text _valueView;

        private float _value;
        private string _message;
        private string _sign;

        private Sequence _popSeq;

        public float Value => _value;
        public string Sign => _sign;

        public void Plus(float value)
        {
            _value += value;
            UpdateView();
        }

        public void Multiply(float multiplier)
        {
            _value *= multiplier;
            UpdateView();
        }

        public void SetMessage(string message)
        {
            _message = message;
            UpdateView();
        }

        public void SetSign(string sign)
        {
            _sign = sign;
            UpdateView();
        }

        public void Round()
        {
            _value = Mathf.Floor(_value);
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
            _message = "<sprite index=1>";
            _sign = "";
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
            seq.AppendCallback(() => G.CameraShaker.WeakShake());

            return seq;
        }

        public Tween MoveToAccumulator(Vector2 position)
        {
            var seq = DOTween.Sequence();
            seq.Join(transform.DOMove(position, 0.5f).SetEase(Ease.InBack));
            seq.AppendCallback(() => G.CameraShaker.WeakShake());

            return seq;
        }

        public void Pop()
        {
            _popSeq?.Kill(true);
            _popSeq = DOTween.Sequence();

            _popSeq.Join(_rootView.DOScale(1.25f, 0.15f).SetEase(Ease.OutBack));
            _popSeq.Append(_rootView.DOScale(1f, 0.25f).SetEase(Ease.OutQuad));
        }

        public void Attack(Vector3 position)
        {
            var direction = (position - transform.position).normalized;
            var backPosition = transform.position - direction * 0.5f;
            var nextPosition = position + direction * 0.5f;

            var seq = DOTween.Sequence();
            seq.Join(transform.DOMove(backPosition, 0.5f).SetEase(Ease.OutQuad));
            seq.AppendInterval(0.15f);
            seq.Append(transform.DOMove(nextPosition, 0.25f).SetEase(Ease.InCubic));
            seq.AppendCallback(() => G.CameraShaker.MidShake());
            seq.Append(transform.DOMove(position, 0.75f).SetEase(Ease.OutElastic));
            seq.Join(_rootView.DOLocalMoveY(-0.25f, 0.5f).SetEase(Ease.OutBounce));
            seq.Join(_rootView.DOScale(0.85f, 0.5f));
            seq.Join(_valueView.DOFade(0, 0.5f).SetEase(Ease.OutQuad));
        }

        private void UpdateView()
        {
            _valueView.text = $"{_message}{_sign}{_value}";
        }
    }
}