using UnityEngine;
using R3;
using UI;

namespace Gameplay
{
    public class WordUnitsMovementProvider
    {
        private readonly HandWordUnitsLayout _handLayout;
        private readonly FieldFlowLayout _fieldLayout;

        public WordUnitsMovementProvider(
            HandWordUnitsLayout handWordUnitsGroup,
            FieldFlowLayout fieldWordUnitsGroup)
        {
            _handLayout = handWordUnitsGroup;
            _fieldLayout = fieldWordUnitsGroup;
        }

        public void MoveFromHandToField(WordUnit wordUnit)
        {
            _handLayout.GravitationalPuller.Disable();
            _fieldLayout.GravitationalPuller.Disable();

            _handLayout.Remove(wordUnit.Transform);
            _fieldLayout.Add(wordUnit.Transform);

            _handLayout.Arrange();
            _fieldLayout.Arrange().Subscribe(arrangedUnit =>
            {
                if (arrangedUnit == (ILayoutElement)wordUnit.Transform)
                {
                    _handLayout.GravitationalPuller.Enable();
                    _fieldLayout.GravitationalPuller.Enable();
                }
            });
        }

        public void MoveFromFieldToHand(WordUnit wordUnit)
        {
            _fieldLayout.GravitationalPuller.Disable();
            _handLayout.GravitationalPuller.Disable();

            _fieldLayout.Remove(wordUnit.Transform);
            _handLayout.Add(wordUnit.Transform);

            _fieldLayout.Arrange();
            _handLayout.Arrange().Subscribe(arrangedUnit =>
            {
                if (arrangedUnit == (ILayoutElement)wordUnit.Transform)
                {
                    _fieldLayout.GravitationalPuller.Enable();
                    _handLayout.GravitationalPuller.Enable();

                    _handLayout.DestroyBackplates();
                }
            });
        }
    }
}