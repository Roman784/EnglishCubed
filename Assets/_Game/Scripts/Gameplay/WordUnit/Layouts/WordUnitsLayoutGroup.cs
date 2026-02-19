using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

namespace Gameplay
{
    public abstract class WordUnitsLayoutGroup : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private float _spacing;
        [SerializeField] protected float _wordUnitScale;

        protected Dictionary<WordUnit, Vector2> _wordUnitPositionsMap = new();

        public abstract void Add(WordUnit wordUnit);
        public abstract void Remove(WordUnit wordUnit);
        protected abstract void Move(WordUnit wordUnit, Vector2 position, float scale);

        private Vector2 WordUnitSize(WordUnit wordUnit) => wordUnit.ContainerSize * _wordUnitScale;

        protected void Arrange(IEnumerable<WordUnit> wordUnits)
        {
            if (wordUnits.Count() == 0) return;

            var wordUnitPositionsMap = new Dictionary<WordUnit, Vector2>();

            var containerCorners = new Vector3[4];
            _container.GetWorldCorners(containerCorners);

            var minScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);
            var containerWidth = maxScreenContainerCorner.x - minScreenContainerCorner.x;

            var currentLineWidth = 0f;
            var lines = new List<List<WordUnit>>();
            var currentLine = new List<WordUnit>();

            foreach (var wordUnit in wordUnits)
            {
                var wordUnitWidth = WordUnitSize(wordUnit).x;

                // If an element fits into the current line.
                if (currentLineWidth + wordUnitWidth + (currentLine.Count > 0 ? _spacing : 0) <= containerWidth)
                {
                    currentLine.Add(wordUnit);
                    currentLineWidth += wordUnitWidth + (currentLine.Count > 0 ? _spacing : 0);
                }
                else
                {
                    // Start new line.
                    lines.Add(new List<WordUnit>(currentLine));
                    currentLine.Clear();
                    currentLine.Add(wordUnit);
                    currentLineWidth = wordUnitWidth;
                }
            }

            if (currentLine.Count > 0)
                lines.Add(new List<WordUnit>(currentLine));

            if (lines.Count > 0)
            {
                var wordUnitsAndPositionsPair = CenterLines(lines, minScreenContainerCorner, maxScreenContainerCorner);
                foreach (var pair in wordUnitsAndPositionsPair)
                    wordUnitPositionsMap[pair.Item1] = pair.Item2;
            }

            _wordUnitPositionsMap = wordUnitPositionsMap;
        }

        private List<(WordUnit, Vector2)> CenterLines(List<List<WordUnit>> lines, Vector2 minContainerCorner, Vector2 maxContainerCorner)
        {
            if (lines.Count == 0) return null;

            var wordUnitsAndPositionsPair = new List<(WordUnit, Vector2)>();

            var containerWidth = maxContainerCorner.x - minContainerCorner.x;
            var containerHeight = maxContainerCorner.y - minContainerCorner.y;
            var containerX = (minContainerCorner.x + maxContainerCorner.x) / 2f;
            var containerY = (minContainerCorner.y + maxContainerCorner.y) / 2f;

            var wordUnitHeight = WordUnitSize(lines[0][0]).y;
            var totalHeight = lines.Count * (wordUnitHeight + _spacing) - _spacing;
            var startY = totalHeight / 2f + containerY;
            var currentY = startY;

            foreach (var line in lines)
            {
                var totalWidth = 0f;
                foreach (var wordUnit in line)
                    totalWidth += WordUnitSize(wordUnit).x;
                totalWidth += (line.Count - 1) * _spacing;

                var startX = -totalWidth / 2f + containerX;
                var currentX = startX;

                foreach (var wordUnit in line)
                {
                    var position = wordUnit.transform.position;
                    position.x = currentX + WordUnitSize(wordUnit).x / 2f;
                    position.y = currentY - wordUnitHeight / 2f;

                    wordUnitsAndPositionsPair.Add((wordUnit, position));

                    if (wordUnit.Position != (Vector2)position)
                        Move(wordUnit, position, _wordUnitScale);

                    currentX += WordUnitSize(wordUnit).x + _spacing;
                }
                currentY -= wordUnitHeight + _spacing;
            }
            return wordUnitsAndPositionsPair;
        }
    }
}