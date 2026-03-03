using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using Utils;

namespace Gameplay
{
    [RequireComponent(typeof(FieldFlowLayout))]
    public class FieldWordUnitsGroup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _availableWordsCountView;
        [SerializeField] private TMP_Text _discardPointsCountView;
        [SerializeField] private Transform _wordUnitsPointsPoint;

        private List<WordUnit> _allWordUnits = new();
        private FieldFlowLayout _layout;

        private int _maxAvailableWordsCount;
        private int _discardPointsCount;

        public FieldFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;
        public int AllWordUnitsCount => _allWordUnits.Count;
        public Vector2 WordUnitsPointsPoisition => _wordUnitsPointsPoint.position;
        public int DiscardPointsCount => _discardPointsCount;

        private void Awake()
        {
            _layout = GetComponent<FieldFlowLayout>();
        }

        public void SetMaxAvailableWordsCount(int count)
        {
            _maxAvailableWordsCount = count;
            UpdateAvailableWordsCountView();
        }

        public void SetDiscardPointsCount(int count)
        {
            _discardPointsCount = count;
            UpdateDiscardPointsCountView();
        }

        public bool CanAdd() => AllWordUnitsCount < _maxAvailableWordsCount;
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

        public void SpendDiscardPoint()
        {
            _discardPointsCount -= 1;
            UpdateDiscardPointsCountView();
        }

        public IEnumerable<WordUnit> Discard(Vector2 deckPosition)
        {
            var wordUnits = new List<WordUnit>(_allWordUnits);
            _allWordUnits.Clear();
            _layout.RemoveAll();

            Coroutines.Start(DiscardRoutine(wordUnits, deckPosition));

            return wordUnits;
        }

        private IEnumerator DiscardRoutine(IEnumerable<WordUnit> wordUnits, Vector2 deckPosition)
        {
            foreach (WordUnit wordUnit in wordUnits)
            {
                wordUnit.Discard(deckPosition);
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void UpdateAvailableWordsCountView()
        {
            _availableWordsCountView.text = $"доступно: {(_maxAvailableWordsCount - _allWordUnits.Count)}";
        }

        public void UpdateDiscardPointsCountView()
        {
            _discardPointsCountView.text = $"В мешок x{_discardPointsCount}";
        }
    }
}