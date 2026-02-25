using GameRoot;
using UnityEngine;

namespace Gameplay
{
    public class InHandWordUnitBehavior : WordUnitBehavior
    {
        public InHandWordUnitBehavior(WordUnitBehaviorHandler handler, WordUnit wordUnit) : base(handler, wordUnit)
        {
        }

        public override void Enter()
        {
        }

        public override void OnPointerClick()
        {
            G.WordUnitsMovementProvider.MoveFromHandToField(_wordUnit);
            _handler.SetOnFieldBehavior();
        }
    }
}