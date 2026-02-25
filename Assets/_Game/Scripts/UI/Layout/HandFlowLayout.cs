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
        }

        protected override Tween Move(ILayoutElement element, Vector2 position)
        {
            return element.MoveTo(position);
        }
    }
}