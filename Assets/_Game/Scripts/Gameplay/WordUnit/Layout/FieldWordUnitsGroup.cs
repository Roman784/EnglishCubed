using R3;
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
        private List<WordUnit> _allWordUnits = new();
        private FieldFlowLayout _layout;

        private int _maxAvailableWordsCount;

        private Subject<Unit> _changedSignalSubj = new();

        public FieldFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;
        public int AllElementsCount => _allWordUnits.Count;
        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public void Init(int maxAvailableWordsCount)
        {
            _layout = GetComponent<FieldFlowLayout>();
            _maxAvailableWordsCount = maxAvailableWordsCount;
        }

        public bool CanMoveIn() => AllElementsCount < _maxAvailableWordsCount;
        public bool CanMoveOut(WordUnit wordUnit) => _allWordUnits.Contains(wordUnit);

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _layout.Add(wordUnit.Transform);
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
            _layout.Remove(wordUnit.Transform);
            _changedSignalSubj.OnNext(Unit.Default);
        }

        public IEnumerable<WordUnit> Discard(Vector2 deckPosition)
        {
            var wordUnits = new List<WordUnit>(_allWordUnits);
            _allWordUnits.Clear();
            _layout.RemoveAll();
            _changedSignalSubj.OnNext(Unit.Default);

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
    }
}