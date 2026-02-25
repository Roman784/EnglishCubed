using UnityEngine;
using R3;

namespace Gameplay
{
    public class WordUnitsMovementProvider
    {
        private readonly HandWordUnitsGroup _handWordUnitsGroup;
        private readonly FieldWordUnitsGroup _fieldWordUnitsGroup;

        public WordUnitsMovementProvider(
            HandWordUnitsGroup handWordUnitsGroup, 
            FieldWordUnitsGroup fieldWordUnitsGroup)
        {
            _handWordUnitsGroup = handWordUnitsGroup;
            _fieldWordUnitsGroup = fieldWordUnitsGroup;
        }

        public void MoveFromHandToField(WordUnit wordUnit)
        {
            _handWordUnitsGroup.GravitationalPuller.Disable();
            _fieldWordUnitsGroup.GravitationalPuller.Disable();

            _handWordUnitsGroup.Remove(wordUnit);
            _fieldWordUnitsGroup.Add(wordUnit);

            _handWordUnitsGroup.Arrange();
            _fieldWordUnitsGroup.Arrange().Subscribe(arrangedUnit =>
            {
                if (arrangedUnit == wordUnit)
                {
                    _handWordUnitsGroup.GravitationalPuller.Enable();
                    _fieldWordUnitsGroup.GravitationalPuller.Enable();
                }
            });
        }

        public void MoveFromFieldToHand(WordUnit wordUnit)
        {
            _fieldWordUnitsGroup.GravitationalPuller.Disable();
            _handWordUnitsGroup.GravitationalPuller.Disable();

            _fieldWordUnitsGroup.Remove(wordUnit);
            _handWordUnitsGroup.Add(wordUnit);

            _fieldWordUnitsGroup.Arrange();
            _handWordUnitsGroup.Arrange().Subscribe(_ =>
            {
                _fieldWordUnitsGroup.GravitationalPuller.Enable();
                _handWordUnitsGroup.GravitationalPuller.Enable();
            });
        }
    }
}