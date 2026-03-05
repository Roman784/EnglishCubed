using R3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(HandFlowLayout))]
    public class HandWordUnitsGroup : MonoBehaviour
    {
        private List<WordUnit> _allWordUnits = new();
        private Dictionary<WordUnit, WordUnitBackplate> _backplatesMap = new();
        private List<WordUnitBackplate> _backplatesForDestruction = new();

        private HandFlowLayout _layout;

        private Subject<Unit> _changedSignalSubj = new();

        public HandFlowLayout Layout => _layout;
        public int AllElementsCount => _layout.AllElementsCount; // Including backplates.
        public Observable<Unit> ChangedSignal => _changedSignalSubj;

        public void Init()
        {
            _layout = GetComponent<HandFlowLayout>();
        }

        public bool CanMoveIn(WordUnit wordUnit) => _backplatesMap.ContainsKey(wordUnit);
        public bool CanMoveOut(WordUnit wordUnit) => _allWordUnits.Contains(wordUnit);

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);

            if (_backplatesMap.TryGetValue(wordUnit, out var backplate) &&
                _layout.Contains(backplate))
            {
                var idx = _layout.IndexOf(backplate);
                _layout.Insert(idx, wordUnit.Transform);
                _layout.Remove(backplate);
                _backplatesMap.Remove(wordUnit);
                _backplatesForDestruction.Add(backplate);
                return;
            }

            _layout.Add(wordUnit.Transform);
            _changedSignalSubj.OnNext(Unit.Default);
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);

            var createdBackplate = Object.Instantiate(wordUnit.BackplatePrefab);
            createdBackplate.SetSize(wordUnit.Transform.ContainerSize);
            createdBackplate.transform.position = wordUnit.Transform.Position;
            _backplatesMap[wordUnit] = createdBackplate;

            var idx = _layout.IndexOf(wordUnit.Transform);
            _layout.Insert(idx, createdBackplate);
            _layout.Remove(wordUnit.Transform);

            _changedSignalSubj.OnNext(Unit.Default);
        }

        public void DestroyLinkedBackplates(IEnumerable<WordUnit> wordUnits)
        {
            foreach (var wordUnit in wordUnits)
            {
                if (_backplatesMap.TryGetValue(wordUnit, out var backplate))
                    _backplatesForDestruction.Add(backplate);
            }
            DestroyBackplates();
        }

        public void DestroyBackplates()
        {
            if (_backplatesForDestruction.Count == 0) return;

            _backplatesMap = _backplatesMap
                .Where(x => !_backplatesForDestruction.Contains(x.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var backplate in _backplatesForDestruction)
            {
                _layout.Remove(backplate);
                backplate.Destroy();
            }

            _backplatesForDestruction.Clear();
            _changedSignalSubj.OnNext(Unit.Default);
        }
    }
}