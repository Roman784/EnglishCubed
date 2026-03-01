using DG.Tweening;
using Gameplay;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class HandFlowLayout : FlowLayoutGroup
    {
        public void SetInitialElements(IEnumerable<ILayoutElement> elements)
        {
            _allElements.Clear();
            _allElements.AddRange(elements);
            Arrange();
        }

        public bool Contains(ILayoutElement element) => _allElements.Contains(element);
        public int IndexOf(ILayoutElement element) => _allElements.IndexOf(element);
        public void Insert(int idx, ILayoutElement element) => _allElements.Insert(idx, element);

        protected override Tween Move(ILayoutElement element, Vector2 position)
        {
            return element.MoveTo(position);
        }
    }
}