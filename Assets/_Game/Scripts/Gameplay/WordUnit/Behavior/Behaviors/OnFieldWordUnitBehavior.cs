using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class OnFieldWordUnitBehavior : WordUnitBehavior
    {
        private Vector2 _startDraggingPosition;
        private Vector2 _endDraggingPosition;

        public OnFieldWordUnitBehavior(WordUnitBehaviorHandler handler, WordUnit wordUnit) : base(handler, wordUnit)
        {
        }

        public override void Enter()
        {
        }

        public override void OnPointerClick()
        {
            G.FieldWordUnitsGroup.Remove(_wordUnit);
            G.HandWordUnitsGroup.Add(_wordUnit);

            _handler.SetInHandBehavior();
        }

        public override void OnPointerDown()
        {
            /*_startDraggingPosition = _wordUnit.Dragging.Start();
            G.FieldWordUnitsGroup.StartWordUnitDragPreview(_wordUnit);*/
        }

        public override void OnPointerUp()
        {
            /*_endDraggingPosition = _wordUnit.Dragging.Stop();
            G.FieldWordUnitsGroup.ConfirmUnitWordDragPreview();*/
        }
    }
}