using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MessageMan : MonoBehaviour
    {
        [SerializeField] private RectTransform _rootView;
        [SerializeField] private Transform _manView;
        [SerializeField] private RectTransform _messageViewport;
        [SerializeField] private TMP_Text _messageView;
        [SerializeField] private Image _backgroundFade;

        private void Start()
        {
            SetFinalClosingState();
        }

        public void Show(string message)
        {
            _messageView.text = message;

            _rootView.gameObject.SetActive(true);
            _backgroundFade.gameObject.SetActive(true);

            var seq = DOTween.Sequence();

            seq.Join(_backgroundFade.DOFade(128f / 255f, 0.25f));
            seq.Join(_rootView.DOAnchorPosY(0, 0.25f).SetEase(Ease.OutBack));
            seq.Append(_messageViewport.DOScaleX(1, 0.25f).SetEase(Ease.OutBack));
        }

        public void Close()
        {
            var seq = DOTween.Sequence();

            seq.Join(_backgroundFade.DOFade(0f, 0.25f));
            seq.Join(_rootView.DOAnchorPosY(-500, 0.25f).SetEase(Ease.InBack));

            seq.OnComplete(() =>
            {
                SetFinalClosingState();
            });
        }

        private void SetFinalClosingState()
        {
            var backgroundFadeColor = _backgroundFade.color;
            backgroundFadeColor.a = 0f;
            _backgroundFade.color = backgroundFadeColor;
            _backgroundFade.gameObject.SetActive(false);

            _rootView.anchoredPosition = new Vector2(0, -500);
            _messageViewport.localScale = new Vector2(0, 1);

            _rootView.gameObject.SetActive(false);
        }
    }
}