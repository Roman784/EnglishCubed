using DG.Tweening;
using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Gameplay
{
    public class FieldWordUnitsGroup : WordUnitsLayoutGroup
    {
        protected override Tween Move(WordUnit wordUnit, Vector2 position)
        {
            if (wordUnit == _lastAddedWordUnit)
                return wordUnit.Transform.MoveToByDecreasing(position);
            else
                return wordUnit.Transform.MoveTo(position);
        }
    }
}