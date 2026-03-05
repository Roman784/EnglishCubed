using UnityEngine;
using R3;
using UI;

namespace Gameplay
{
    public class WordUnitsMovementProvider
    {
        private HandWordUnitsGroup _handGroup;
        private FieldWordUnitsGroup _fieldLayout;

        private bool _isEnabled;

        public WordUnitsMovementProvider(
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup)
        {
            _handGroup = handWordUnitsGroup;
            _fieldLayout = fieldWordUnitsGroup;
            _isEnabled = true;
        }

        public void Enable()
        {
            _isEnabled = true;
            _handGroup.Layout.GravitationalPuller.Enable();
            _fieldLayout.Layout.GravitationalPuller.Enable();
        }

        public void Disable()
        {
            _isEnabled = false;
            _handGroup.Layout.GravitationalPuller.Disable();
            _fieldLayout.Layout.GravitationalPuller.Disable();
        }

        public bool TryMoveFromHandToField(WordUnit wordUnit)
        {
            if (!_isEnabled || 
                !_fieldLayout.CanMoveIn() || 
                !_handGroup.CanMoveOut(wordUnit)) return false;

            _handGroup.Layout.GravitationalPuller.Disable();
            _fieldLayout.Layout.GravitationalPuller.Disable();

            _fieldLayout.Add(wordUnit);
            _handGroup.Remove(wordUnit);

            _handGroup.Layout.Arrange();
            _fieldLayout.Layout.Arrange().Subscribe(arrangedUnit =>
            {
                if (arrangedUnit == (ILayoutElement)wordUnit.Transform)
                {
                    _handGroup.Layout.GravitationalPuller.Enable();
                    _fieldLayout.Layout.GravitationalPuller.Enable();
                }
            });

            return true;
        }

        public bool TryMoveFromFieldToHand(WordUnit wordUnit)
        {
            if (!_isEnabled || 
                !_fieldLayout.CanMoveOut(wordUnit) || 
                !_handGroup.CanMoveIn(wordUnit)) return false;

            _fieldLayout.Layout.GravitationalPuller.Disable();
            _handGroup.Layout.GravitationalPuller.Disable();

            _fieldLayout.Remove(wordUnit);
            _handGroup.Add(wordUnit);

            _fieldLayout.Layout.Arrange();
            _handGroup.Layout.Arrange().Subscribe(arrangedUnit =>
            {
                if (arrangedUnit == (ILayoutElement)wordUnit.Transform)
                {
                    _fieldLayout.Layout.GravitationalPuller.Enable();
                    _handGroup.Layout.GravitationalPuller.Enable();

                    _handGroup.DestroyBackplates();
                }
            });

            return true;
        }
    }
}