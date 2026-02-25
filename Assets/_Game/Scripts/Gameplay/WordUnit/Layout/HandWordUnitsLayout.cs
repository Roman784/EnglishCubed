using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class HandWordUnitsLayout : HandFlowLayout
    {
        private Dictionary<ILayoutElement, WordUnitBackplate> _backplatesMap = new();
        private List<WordUnitBackplate> _backplatesForDestruction = new();

        public override void Add(ILayoutElement wordUnit)
        {
            if (_backplatesMap.TryGetValue(wordUnit, out var backplate) &&
                _allElements.Contains(backplate))
            {
                var idx = _allElements.IndexOf(backplate);
                _allElements.Insert(idx, wordUnit);
                _allElements.Remove(backplate);
                _backplatesMap.Remove(wordUnit);
                _backplatesForDestruction.Add(backplate);
                return;
            }

            base.Add(wordUnit);
        }

        public override void Remove(ILayoutElement element)
        {
            var createdBackplate = Instantiate(((WordUnitTransform)element).BackplatePrefab);
            createdBackplate.SetSize(element.ContainerSize);
            createdBackplate.transform.position = element.Position;
            _backplatesMap[element] = createdBackplate;

            var idx = _allElements.IndexOf(element);
            _allElements.Insert(idx, createdBackplate);
            _allElements.Remove(element);
        }

        public void DestroyBackplates()
        {
            if (_backplatesForDestruction.Count == 0) return;
            foreach (var backplate in _backplatesForDestruction)
            {
                Destroy(backplate.gameObject);
            }
            _backplatesForDestruction.Clear();
        }
    }
}