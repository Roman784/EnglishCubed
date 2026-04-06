using DG.Tweening;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class EncounterButton : MonoBehaviour
    {
        [SerializeField] private Image _iconView;
        [SerializeField] private Image _backgroundView;
        [SerializeField] private Transform _selectionView;

        [Space]

        [SerializeField] private Color _completedColor;
        [SerializeField] private Sprite _hideSprite;
        [SerializeField] private Sprite _combatSprite;

        private RectTransform _rectTransform;
        private bool _isLocked;
        private bool _isPassed;
        private Subject<Unit> _selectedSignalSubj = new();

        public RectTransform RectTransform => _rectTransform;
        public bool IsLocked => _isLocked;
        public bool IsPassed => _isPassed;
        public Observable<Unit> SelectedSignal => _selectedSignalSubj;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            Deselect();
        }

        public void Press()
        {
            _selectedSignalSubj.OnNext(Unit.Default);
        }

        public void Select()
        {
            _selectionView.gameObject.SetActive(true);
            _selectionView.localScale = Vector3.one * 0.85f;
            _selectionView.DOKill(true);
            _selectionView.DOScale(1, 0.15f).SetEase(Ease.OutBack);
        }

        public void Deselect()
        {
            _selectionView.gameObject.SetActive(false);
            _selectionView.localScale = Vector3.zero;
        }

        public void SetCombat()
        {
            _iconView.sprite = _combatSprite;
        }

        public void Unlock()
        {
            _isLocked = false;
        }

        public void Hide()
        {
            _isLocked = true;
            _iconView.sprite = _hideSprite;
        }

        public void Complete()
        {
            _isLocked = true;
            _isPassed = true;
            _backgroundView.color = _completedColor;
        }
    }
}