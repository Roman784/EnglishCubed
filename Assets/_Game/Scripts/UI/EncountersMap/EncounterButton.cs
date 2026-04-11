using DG.Tweening;
using EncountersMap;
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
        [SerializeField] private Sprite _unknownSprite;
        [SerializeField] private Sprite _combatSprite;
        [SerializeField] private Sprite _emergencyCombatSprite;
        [SerializeField] private Sprite _bossCombatSprite;

        private RectTransform _rectTransform;
        private EncounterName _name;
        private bool _isUnknown;
        private bool _isPassed;
        private Subject<Unit> _selectedSignalSubj = new();

        public RectTransform RectTransform => _rectTransform;
        public bool HasName => _name != EncounterName.None;
        public bool IsUnknown => _isUnknown;
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

        public void SetUnknown(bool value)
        {
            _isUnknown = value;
            if (value)
                _iconView.sprite = _unknownSprite;
        }

        public void SetName(EncounterName encounterName)
        {
            _name = encounterName;

            switch (encounterName)
            {
                case EncounterName.Combat:
                    _iconView.sprite = _combatSprite;
                    break;
                case EncounterName.EmergencyCombat:
                    _iconView.sprite = _emergencyCombatSprite;
                    break;
                case EncounterName.BossCombat:
                    _iconView.sprite = _bossCombatSprite;
                    break;
                default:
                    _iconView.sprite = _unknownSprite;
                    break;
            }
        }

        public void Complete()
        {
            _isUnknown = false;
            _isPassed = true;
            _backgroundView.color = _completedColor;
        }
    }
}