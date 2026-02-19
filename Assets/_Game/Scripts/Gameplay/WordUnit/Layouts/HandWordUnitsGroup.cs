using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace Gameplay
{
    public class HandWordUnitsGroup : WordUnitsLayoutGroup
    {
        public void SetWordUnits(IEnumerable<WordUnit> wordUnits)
        {
            Arrange(wordUnits);
            CreateBackplates(_wordUnitPositionsMap);
        }

        public override void Add(WordUnit wordUnit) 
        {
            if (_wordUnitPositionsMap.TryGetValue(wordUnit, out Vector2 position))
            {
                wordUnit.MoveToByDecreasing(position, _wordUnitScale);
            }
        }

        public override void Remove(WordUnit wordUnit) { }

        protected override void Move(WordUnit wordUnit, Vector2 position, float _)
        {
            wordUnit.MoveTo(position);
        }

        private void CreateBackplates(IReadOnlyDictionary<WordUnit, Vector2> wordUnitPositionsMap)
        {
            foreach (var pair in wordUnitPositionsMap)
            {
                var createdBackplate = Instantiate(pair.Key.Backplate, pair.Value, Quaternion.identity);
                createdBackplate.sizeDelta = pair.Key.ContainerSize;
                createdBackplate.gameObject.SetActive(true);
            }
        }
    }
}