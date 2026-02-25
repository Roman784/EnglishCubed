using DG.Tweening;
using R3;
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
            _allWordUnits.Clear();
            _allWordUnits.AddRange(wordUnits);
            Arrange();
            //CreateBackplates(_wordUnitPositionsMap);
        }

        public override void Add(WordUnit wordUnit) 
        {
            base.Add(wordUnit);

            /*if (_wordUnitPositionsMap.TryGetValue(wordUnit, out Vector2 position))
            {
                wordUnit.Transform.MoveToByDecreasing(position);
            }*/
        }

        protected override Tween Move(WordUnit wordUnit, Vector2 position)
        {
            return wordUnit.Transform.MoveTo(position);
        }

        private void CreateBackplates(IReadOnlyDictionary<WordUnit, Vector2> wordUnitPositionsMap)
        {
            foreach (var pair in wordUnitPositionsMap)
            {
                var createdBackplate = Instantiate(pair.Key.Backplate, pair.Value, Quaternion.identity);
                createdBackplate.sizeDelta = pair.Key.Transform.ContainerSize;
                createdBackplate.gameObject.SetActive(true);
            }
        }
    }
}