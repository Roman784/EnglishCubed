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
            G.HandWordUnitsGroup.Remove(_wordUnit);
            G.FieldWordUnitsGroup.Add(_wordUnit);

            _handler.SetOnFieldBehavior();
        }
    }
}