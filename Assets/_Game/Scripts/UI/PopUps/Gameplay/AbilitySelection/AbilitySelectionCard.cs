using Abilities;
using Configs;
using DG.Tweening;
using GameRoot;
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

        private Sequence _showingSequence;

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
            _pointerDetector.OnPointerClickSignal.Subscribe(_ => Select());
        }

        public void Init(AbilitySelectionData ability)
        {
            var levelData = ability.GetLevelData();

            if (levelData == null)
            {
                Debug.LogError($"Level data for ability {ability.Configs.Name} is not set up properly!");
                return;
            }

            _iconView.sprite = levelData.Icon;
            _titleView.text = G.LocalizationProvider.GetTranslation(levelData.Title);

            if (levelData.Values != null)
                _descriptionView.text = 
                    $"{G.LocalizationProvider.GetTranslation(levelData.Description)}" +
                    $"\n\n" +
                    $"{G.LocalizationProvider.GetTranslation(levelData.Details).InsertValues(levelData.Values)}";
        }

        public Observable<Unit> Show()
        {
            var onCompleted = new Subject<Unit>();
            _showingSequence = DOTween.Sequence();

            _showingSequence.Append(transform.DOScaleX(0, 0.35f).SetEase(Ease.InQuart));
            _showingSequence.AppendCallback(() =>
            {
                _backViewport.gameObject.SetActive(false);
                _frontViewport.gameObject.SetActive(true);
            });
            _showingSequence.Append(transform.DOScaleX(1, 0.35f).SetEase(Ease.OutQuart));

            _showingSequence.AppendCallback(() =>
            {
                _pointerDetector.Enable();
                onCompleted.OnNext(Unit.Default);
                onCompleted.OnCompleted();
            });

            _showingSequence.Append(DOTween.To
            (
                () => _descriptionViewport.offsetMin.y,
                y => { _descriptionViewport.offsetMin = new Vector2(_descriptionViewport.offsetMin.x, y); },
                0,
                1.5f
            ).SetEase(Ease.OutElastic, amplitude: 0f, period: 0.75f));

            return onCompleted;
        }

        public Tween Hide()
        {
            _showingSequence?.Kill();

            _pointerDetector.enabled = false;
            var seq = DOTween.Sequence();

            seq.Append(DOTween.To
            (
                () => _descriptionViewport.offsetMin.y,
                y => { _descriptionViewport.offsetMin = new Vector2(_descriptionViewport.offsetMin.x, y); },
                370,
                0.5f
            ).SetEase(Ease.InBack));
            seq.AppendCallback(() =>
            {
                _backViewport.gameObject.SetActive(false);
                _frontViewport.gameObject.SetActive(false);
            });

            return seq;
        }

        public void Select()
        {
            _selectSignalSubj.OnNext(Unit.Default);
            _selectSignalSubj.OnCompleted();
        }
    }
}