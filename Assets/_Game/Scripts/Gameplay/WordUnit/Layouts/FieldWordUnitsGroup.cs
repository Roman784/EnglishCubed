using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class FieldWordUnitsGroup : WordUnitsLayoutGroup
    {
        private List<WordUnit> _allWordUnits = new();
        private WordUnit _addedWordUnit;

        public override void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _addedWordUnit = wordUnit;
            Arrange(_allWordUnits);
        }

        public override void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
            _addedWordUnit = null;
            Arrange(_allWordUnits);
        }

        protected override void Move(WordUnit wordUnit, Vector2 position, float scale)
        {
            if (wordUnit == _addedWordUnit)
                wordUnit.MoveToByDecreasing(position, scale);
            else
                wordUnit.MoveTo(position);
        }
    }
}