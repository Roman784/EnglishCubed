using Configs;
using Gameplay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class DeckPopUp : PopUp
    {
        [Space]

        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private HandFlowLayout _layout;

        public void Open(IEnumerable<WordUnitConfigs> wordUnitsConfigs)
        {
            CreateWordUnits(wordUnitsConfigs);
        }

        private void CreateWordUnits(IEnumerable<WordUnitConfigs> wordUnitsConfigs)
        {
            var wordUnits = new List<WordUnit>();
            foreach (var configs in wordUnitsConfigs)
            {
                wordUnits.Add(CreateWordUnit(configs));
            }
            _layout.SetInitialElements(wordUnits.Select(w => w.Transform), true);
        }

        private WordUnit CreateWordUnit(WordUnitConfigs wordUnitConfigs)
        {
            var createWord = Instantiate(_wordUnitPrefab, transform.position, Quaternion.identity);
            createWord.transform.SetParent(_layout.Container, true);
            createWord.SetConfigs(wordUnitConfigs);
            createWord.Transform.ZeroRootViewScale();
            return createWord;
        }
    }
}