using DG.Tweening;
using Gameplay;
using UnityEngine;

namespace UI
{
    public class FieldFlowLayout : FlowLayoutGroup
    {
        protected override Tween Move(ILayoutElement element, Vector2 position)
        {
            if (_newElements.Contains(element))
                return element.MoveToByDecreasing(position);
            else
                return element.MoveTo(position);
        }
    }
}