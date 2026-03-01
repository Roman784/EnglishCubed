using UnityEngine;
using R3;
using UI;

namespace Gameplay
{
    public class WordUnitsMovementProvider
    {
        private readonly HandWordUnitsGroup _handGroup;
        private readonly FieldWordUnitsGroup _fieldLayout;

        public WordUnitsMovementProvider(
            HandWordUnitsGroup handWordUnitsGroup,
            FieldWordUnitsGroup fieldWordUnitsGroup)
        {
            _handGroup = handWordUnitsGroup;
            _fieldLayout = fieldWordUnitsGroup;
        }

        public void MoveFromHandToField(WordUnit wordUnit)
        {
            _handGroup.Layout.GravitationalPuller.Disable();
            _fieldLayout.Layout.GravitationalPuller.Disable();

            _handGroup.Remove(wordUnit);
            _fieldLayout.Add(wordUnit);

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