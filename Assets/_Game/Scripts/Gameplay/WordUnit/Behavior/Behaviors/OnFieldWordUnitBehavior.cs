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
            G.FieldWordUnitsGroup.Remove(_wordUnit);
            G.HandWordUnitsGroup.Add(_wordUnit);

            _handler.SetInHandBehavior();
        }
    }
}