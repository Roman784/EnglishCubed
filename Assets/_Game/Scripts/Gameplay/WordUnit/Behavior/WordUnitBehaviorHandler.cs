using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitBehaviorHandler
    {
        private readonly WordUnit _wordUnit;

        private Dictionary<Type, WordUnitBehavior> _behaviorsMap;
        private WordUnitBehavior _currentBehavior;

        public WordUnitBehaviorHandler(WordUnit wordUnit)
        {
            _wordUnit = wordUnit;
            InitBehaviorsMap();
        }

        private void InitBehaviorsMap()
        {
            _behaviorsMap = new();

            _behaviorsMap[typeof(InHandWordUnitBehavior)] = new InHandWordUnitBehavior(this, _wordUnit);
            _behaviorsMap[typeof(OnFieldWordUnitBehavior)] = new OnFieldWordUnitBehavior(this, _wordUnit);
        }

        public void HandleOnClick() => _currentBehavior?.OnPointerClick();

        public void SetInHandBehavior()
        {
            var behavior = GetBehavior<InHandWordUnitBehavior>();
            SetBehavior(behavior);
        }

        public void SetOnFieldBehavior()
        {
            var behavior = GetBehavior<OnFieldWordUnitBehavior>();
            SetBehavior(behavior);
        }

        private void SetBehavior(WordUnitBehavior behavior)
        {
            _currentBehavior?.Exit();

            _currentBehavior = behavior;
            _currentBehavior.Enter();
        }

        private WordUnitBehavior GetBehavior<T>() where T : WordUnitBehavior
        {
            return _behaviorsMap[typeof(T)];
        }
    }
}