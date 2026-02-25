using DG.Tweening;
using UnityEngine;

namespace UI
{
    public interface ILayoutElement
    {
        public Transform Transform { get; }
        public Vector2 Position { get; }
        public Vector2 ContainerSize { get; }

        public Tween MoveTo(Vector2 to);
        public Tween MoveToByDecreasing(Vector2 to);
        public Tween MoveViewToLocal(Vector2 to); 
    }
}