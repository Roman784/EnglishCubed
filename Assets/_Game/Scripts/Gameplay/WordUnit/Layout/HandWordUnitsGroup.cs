using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class HandWordUnitsGroup
    {
        private List<WordUnit> _allWordUnits = new();
        private Dictionary<WordUnit, WordUnitBackplate> _backplatesMap = new();
        private List<WordUnitBackplate> _backplatesForDestruction = new();

        private HandFlowLayout _layout;

        public HandFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;

        public HandWordUnitsGroup(HandFlowLayout layout)
        {
            _layout = layout;
        }

        public void SetInitialWordUnits(IEnumerable<WordUnit> wordUnits)
        {
            _allWordUnits = new List<WordUnit>(wordUnits);
            _layout.SetInitialElements(wordUnits.Select(w => w.Transform));
        }

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
        }

        public void DestroyBackplates()
        {
            if (_backplatesForDestruction.Count == 0) return;
            foreach (var backplate in _backplatesForDestruction)
            {
                Object.Destroy(backplate.gameObject);
            }
            _backplatesForDestruction.Clear();
        }
    }
}