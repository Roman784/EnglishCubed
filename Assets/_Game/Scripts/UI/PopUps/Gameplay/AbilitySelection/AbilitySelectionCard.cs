using DG.Tweening;
using GrammarValidation;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class AbilitySelectionCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleView;
        [SerializeField] private TMP_Text _descriptionView;
        [SerializeField] private Image _iconView;

        [Space]

        [SerializeField] private RectTransform _frontViewport;
        [SerializeField] private RectTransform _backViewport;
        [SerializeField] private RectTransform _descriptionViewport;
        [SerializeField] private PointerDetector _pointerDetector;

        private bool _isEnabled;

        private Subject<Unit> _selectSignalSubj = new();
        public Observable<Unit> SelectSignal => _selectSignalSubj;

        private void Awake()
        {
            transform.localScale = Vector3.zero;
            _frontViewport.gameObject.SetActive(false);
            _backViewport.gameObject.SetActive(true);
            _descriptionViewport.offsetMin = new Vector2(_descriptionViewport.offsetMin.x, 370);

            transform.localScale = Vector3.one * 0.5f;
            transform.DOScale(1, 0.25f).SetEase(Ease.OutBack);

            _pointerDetector.Disable();
        }

        public void Show()
        {
            var seq = DOTween.Sequence();

            seq.Append(transform.DOScaleX(0, 0.35f).SetEase(Ease.InQuart));
            seq.AppendCallback(() =>
            {
                _backViewport.gameObject.SetActive(false);
                _frontViewport.gameObject.SetActive(true);
            });
            seq.Append(transform.DOScaleX(1, 0.35f).SetEase(Ease.OutQuart));
            seq.Append(DOTween.To
            (
                () => _descriptionViewport.offsetMin.y,
                y => { _descriptionViewport.offsetMin = new Vector2(_descriptionViewport.offsetMin.x, y); },
                0,
                1.5f
            ).SetEase(Ease.OutElastic, amplitude: 0f, period: 0.75f));

            seq.OnComplete(() =>
            {
                _isEnabled = true;
                _pointerDetector.Enable();
            });
        }

        public void Select()
        {
            if (!_isEnabled) return;
            _selectSignalSubj.OnNext(Unit.Default);
            _selectSignalSubj.OnCompleted();
        }
    }
}