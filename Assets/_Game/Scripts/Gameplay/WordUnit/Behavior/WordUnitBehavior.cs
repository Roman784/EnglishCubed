using UnityEngine;

namespace Gameplay
{
    public abstract class WordUnitBehavior
    {
        protected readonly WordUnitBehaviorHandler _handler;
        protected readonly WordUnit _wordUnit;

        public WordUnitBehavior(WordUnitBehaviorHandler handler, WordUnit wordUnit)
        {
            _handler = handler;
            _wordUnit = wordUnit;
        }

        public abstract void Enter();
        public virtual void Exit() { }
        public virtual void OnPointerClick() { }
        public virtual void OnPointerEnter() { }
        public virtual void OnPointerExit() { }
        public virtual void OnPointerDown() { }
        public virtual void OnPointerUp() { }
    }
}