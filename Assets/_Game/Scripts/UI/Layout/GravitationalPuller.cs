using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GravitationalPuller
    {
        private readonly RectTransform _container;
        private readonly IEnumerable<ILayoutElement> _elements;
        private readonly float _strength;

        private bool _isEnabled;
        private ILayoutElement _currentHoveredElement;

        public GravitationalPuller(
            RectTransform container, IEnumerable<ILayoutElement> elements, float strength)
        {
            _container = container;
            _elements = elements;
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
                var closestElement = FindClosestElementToPosition(mousePosition);

                if (closestElement != null && closestElement != _currentHoveredElement)
                {
                    _currentHoveredElement = closestElement;
                    PushAwayFrom(closestElement);
                }
            }
            else
            {
                if (_currentHoveredElement != null)
                {
                    _currentHoveredElement = null;
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

        private ILayoutElement FindClosestElementToPosition(Vector2 position)
        {
            var minDistance = float.MaxValue;
            ILayoutElement closestElement = null;

            foreach (var element in _elements)
            {
                var distance = (position - element.Position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestElement = element;
                }
            }

            return closestElement;
        }

        private void PushAwayFrom(ILayoutElement centralElement)
        {
            var centralPosition = centralElement.Position;
            centralElement.MoveViewToLocal(Vector2.zero);

            foreach (var element in _elements)
            {
                if (element == centralElement) continue;

                var currentPosition = element.Position;
                var direction = currentPosition - centralPosition;
                var distance = direction.magnitude;
                var newPosition = direction.normalized * (_strength / Mathf.Sqrt(distance));

                element.MoveViewToLocal(newPosition);
            }
        }

        private void ReturnAllToOriginalPositions()
        {
            foreach (var element in _elements)
            {
                element.MoveViewToLocal(Vector2.zero);
            }
        }
    }
}