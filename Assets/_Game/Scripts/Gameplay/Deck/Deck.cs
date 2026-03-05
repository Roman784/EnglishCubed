using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Deck
    {
        private List<WordUnitConfigs> _allWordUnits;

        public IEnumerable<WordUnitConfigs> AllWordUnits => _allWordUnits;

        public bool HasAnyWordUnit => _allWordUnits.Count > 0;

        public Deck(IEnumerable<WordUnitConfigs> wordUnits = null)
        {
            _allWordUnits = new List<WordUnitConfigs>();

            if (wordUnits != null)
                Add(wordUnits);
        }

        public void Add(IEnumerable<WordUnitConfigs> wordUnits)
        {
            _allWordUnits.AddRange(wordUnits);
        }


        public void Add(WordUnitConfigs wordUnit)
        {
            _allWordUnits.Add(wordUnit);
        }

        public WordUnitConfigs DrawRandom()
        {
            if (_allWordUnits.Count == 0) return null;

            var index = Random.Range(0, _allWordUnits.Count);
            var configs = _allWordUnits[index];
            _allWordUnits.RemoveAt(index);
            return configs;
        }

        public void Remove(WordUnitConfigs configs)
        {
            if (!_allWordUnits.Contains(configs)) return;
            _allWordUnits.Remove(configs);
        }
    }
}