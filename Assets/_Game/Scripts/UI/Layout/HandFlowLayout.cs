using DG.Tweening;
using Gameplay;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class HandFlowLayout : FlowLayoutGroup
    {
        public void SetWordUnits(IEnumerable<ILayoutElement> elements)
        {
            _allElements.Clear();
            _allElements.AddRange(elements);
            Arrange();
            //CreateBackplates(_wordUnitPositionsMap);
        }

        public override void Add(ILayoutElement element)
        {
            base.Add(element);

            /*if (_wordUnitPositionsMap.TryGetValue(wordUnit, out Vector2 position))
            {
                wordUnit.Transform.MoveToByDecreasing(position);
            }*/
        }

        public override void Remove(ILayoutElement element)
        {
            base.Remove(element);
        }

        protected override Tween Move(ILayoutElement element, Vector2 position)
        {
            return element.MoveTo(position);
        }

        /*private void CreateBackplates(IReadOnlyDictionary<ILayoutElement, Vector2> wordUnitPositionsMap)
        {
            foreach (var pair in wordUnitPositionsMap)
            {
                var createdBackplate = Instantiate(pair.Key.Backplate, pair.Value, Quaternion.identity);
                createdBackplate.sizeDelta = pair.Key.Transform.ContainerSize;
                createdBackplate.gameObject.SetActive(true);
            }
        }*/
    }
}