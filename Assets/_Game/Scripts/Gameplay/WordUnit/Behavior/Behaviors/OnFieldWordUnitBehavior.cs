using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class OnFieldWordUnitBehavior : WordUnitBehavior
    {
        public OnFieldWordUnitBehavior(WordUnitBehaviorHandler handler, WordUnit wordUnit) : base(handler, wordUnit)
        {
        }

        public override void Enter()
        {
        }

        public override void OnPointerClick()
        {
            G.WordUnitsMovementProvider.MoveFromFieldToHand(_wordUnit);
            _handler.SetInHandBehavior();
        }
    }
}