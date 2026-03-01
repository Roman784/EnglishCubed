using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(FieldFlowLayout))]
    public class FieldWordUnitsGroup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _availableWordsCountView;

        private List<WordUnit> _allWordUnits = new();
        private FieldFlowLayout _layout;

        private int _maxAvailableWordsCount;

        public FieldFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;

        private void Awake()
        {
            _layout = GetComponent<FieldFlowLayout>();
        }

        public void SetMaxAvailableWordsCount(int count)
        {
            _maxAvailableWordsCount = count;
            UpdateAvailableWordsCountView();
        }

        public bool CanAdd() => _allWordUnits.Count < _maxAvailableWordsCount;
        public bool CanRemove(WordUnit wordUnit) => _allWordUnits.Contains(wordUnit);

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _layout.Add(wordUnit.Transform);

            UpdateAvailableWordsCountView();
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
            _layout.Remove(wordUnit.Transform);

            UpdateAvailableWordsCountView();
        }

        private void UpdateAvailableWordsCountView()
        {
            _availableWordsCountView.text = $"доступно: {(_maxAvailableWordsCount - _allWordUnits.Count)}";
        }
    }
}