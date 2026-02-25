using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitsGravitationalPuller
    {
        private readonly RectTransform _container;
        private readonly IEnumerable<WordUnit> _wordUnits;
        private readonly float _strength;

        private bool _isEnabled;
        private WordUnit _currentHoveredUnit;

        public WordUnitsGravitationalPuller(
            RectTransform container, IEnumerable<WordUnit> wordUnits, float strength)
        {
            _container = container;
            _wordUnits = wordUnits;
            _strength = strength;

            _isEnabled = true;
        }

        public void Enable() => _isEnabled = true;
        public void Disable()
        {
            _isEnabled = false;
            ReturnAllToOriginalPositions();
        }

        public void Handle()
        {
            if (!_isEnabled) return;

            if (IsMouseOverContainer())
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestUnit = FindClosestWordUnitToPosition(mousePosition);

                if (closestUnit != null && closestUnit != _currentHoveredUnit)
                {
                    _currentHoveredUnit = closestUnit;
                    PushAwayFrom(closestUnit);
                }
            }
            else
            {
                if (_currentHoveredUnit != null)
                {
                    _currentHoveredUnit = null;
                    ReturnAllToOriginalPositions();
                }
            }
        }

        private bool IsMouseOverContainer()
        {
            if (_container == null) return false;

            var containerCorners = new Vector3[4];
            _container.GetWorldCorners(containerCorners);

            var minCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return mousePosition.x >= minCorner.x &&
                   mousePosition.x <= maxCorner.x &&
                   mousePosition.y >= minCorner.y &&
                   mousePosition.y <= maxCorner.y;
        }

        private WordUnit FindClosestWordUnitToPosition(Vector2 position)
        {
            var minDistance = float.MaxValue;
            WordUnit closestUnit = null;

            foreach (var wordUnit in _wordUnits)
            {
                var distance = (position - wordUnit.Position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestUnit = wordUnit;
                }
            }

            return closestUnit;
        }

        private void PushAwayFrom(WordUnit centralUnit)
        {
            var centralPosition = centralUnit.Position;
            centralUnit.Transform.MoveViewToLocal(Vector2.zero);

            foreach (var wordUnit in _wordUnits)
            {
                if (wordUnit == centralUnit) continue;

                var currentPosition = wordUnit.Position;
                var direction = currentPosition - centralPosition;
                var distance = direction.magnitude;
                var newPosition = direction.normalized * (_strength / Mathf.Sqrt(distance));

                wordUnit.Transform.MoveViewToLocal(newPosition);
            }
        }

        private void ReturnAllToOriginalPositions()
        {
            foreach (var wordUnit in _wordUnits)
            {
                wordUnit.Transform.MoveViewToLocal(Vector2.zero);
            }
        }
    }
}