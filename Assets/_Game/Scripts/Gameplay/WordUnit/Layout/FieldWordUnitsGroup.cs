using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class FieldWordUnitsGroup
    {
        private List<WordUnit> _allWordUnits = new();
        private FieldFlowLayout _layout;

        public FieldFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;

        public FieldWordUnitsGroup(FieldFlowLayout layout)
        {
            _layout = layout;
        }

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _layout.Add(wordUnit.Transform);
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
            _layout.Remove(wordUnit.Transform);
        }
    }
}