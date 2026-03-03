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
        [SerializeField] private Transform _wordUnitsPointsPoint;

        private List<WordUnit> _allWordUnits = new();
        private FieldFlowLayout _layout;

        private int _maxAvailableWordsCount;

        public FieldFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;
        public Vector2 WordUnitsPointsPoisition => _wordUnitsPointsPoint.position;

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
                yield return new WaitForSeconds(0.15f);
                wordUnit.Discard(deckPosition);
            }
        }

        private void UpdateAvailableWordsCountView()
        {
            _availableWordsCountView.text = $"доступно: {(_maxAvailableWordsCount - _allWordUnits.Count)}";
        }
    }
}