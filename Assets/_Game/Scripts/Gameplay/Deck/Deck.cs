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

        public WordUnitConfigs GetRandom()
        {
            if (_allWordUnits.Count == 0) return null;
            return _allWordUnits[Random.Range(0, _allWordUnits.Count)];
        }

        public void Remove(WordUnitConfigs configs)
        {
            if (!_allWordUnits.Contains(configs)) return;
            _allWordUnits.Remove(configs);
        }
    }
}