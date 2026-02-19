using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace Gameplay
{
    public class WordUnitDragging
    {
        private readonly Transform _transform;
        private Vector2 _hookPosition;
        private Coroutine _dragRoutine;

        public Vector2 HookPosition => _hookPosition;

        public WordUnitDragging(Transform transform)
        {
            _transform = transform;
            _hookPosition = transform.position;
        }

        public Vector2 Start()
        {
            var startPosition = _transform.position;
            _dragRoutine = Coroutines.Start(DragRoutine());
            return startPosition;
        }

        public Vector2 Stop()
        {
            Coroutines.Stop(_dragRoutine);
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, 0);
            _hookPosition = _transform.position;
            return _transform.position;
        }

        public IEnumerator DragRoutine()
        {
            var camera = Camera.main;
            var startPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            var offset = startPosition - _transform.position;

            while (true)
            {
                yield return null;

                _hookPosition = camera.ScreenToWorldPoint(Input.mousePosition) - offset;
                _transform.position = new Vector3(_hookPosition.x, _hookPosition.y, -1);
            }
        }
    }
}