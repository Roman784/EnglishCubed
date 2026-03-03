using UnityEngine;
using R3;
using UI;

namespace Gameplay
{
    public class WordUnitsMovementProvider
    {
        private readonly HandWordUnitsGroup _handGroup;
        private readonly FieldWordUnitsGroup _fieldLayout;

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

        public void MoveFromHandToField(WordUnit wordUnit)
        {
            if (!_isEnabled || !_fieldLayout.CanAdd() || !_handGroup.CanRemove(wordUnit)) return;

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
        }

        public void MoveFromFieldToHand(WordUnit wordUnit)
        {
            if (!_isEnabled || !_fieldLayout.CanRemove(wordUnit) || !_handGroup.CanAdd()) return;

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
        }
    }
}