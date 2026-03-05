using Configs;
using Gameplay;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class DeckPopUp : PopUp
    {
        [Space]

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

        private WordUnit CreateWordUnit(WordUnitConfigs configs)
        {
            var createWord = G.WordUnitFactory.Create(configs, transform.position);
            createWord.transform.SetParent(_layout.Container, true);
            return createWord;
        }
    }
}