using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

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
            _addedWordUnit = null;
        }

        public override void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
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