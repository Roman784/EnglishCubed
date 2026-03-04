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
    }
}