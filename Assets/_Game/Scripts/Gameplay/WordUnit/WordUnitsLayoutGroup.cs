using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitsLayoutGroup : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private float _spacing;

        private List<WordUnit> _allWordUnits = new();
        private WordUnit _addedWordUnit;

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _addedWordUnit = wordUnit;
            Arrange();
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
            _addedWordUnit = null;
            Arrange();
        }

        private void Arrange()
        {
            if (_allWordUnits.Count == 0) return;

            var containerCorners = new Vector3[4];
            _container.GetWorldCorners(containerCorners);

            var minScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);
            var containerWidth = maxScreenContainerCorner.x - minScreenContainerCorner.x;

            var currentLineWidth = 0f;
            var lines = new List<List<WordUnit>>();
            var currentLine = new List<WordUnit>();

            for (int i = 0; i < _allWordUnits.Count; i++)
            {
                var wordUnit = _allWordUnits[i];
                var wordUnitWidth = wordUnit.ContainerSize.x;

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
                CenterLines(lines, minScreenContainerCorner, maxScreenContainerCorner);
        }

        private void CenterLines(List<List<WordUnit>> lines, Vector2 minContainerCorner, Vector2 maxContainerCorner)
        {
            if (lines.Count == 0) return;

            var containerWidth = maxContainerCorner.x - minContainerCorner.x;
            var containerHeight = maxContainerCorner.y - minContainerCorner.y;
            var containerX = (minContainerCorner.x + maxContainerCorner.x) / 2f;
            var containerY = (minContainerCorner.y + maxContainerCorner.y) / 2f;

            var wordUnitHeight = lines[0][0].ContainerSize.y;
            var totalHeight = lines.Count * (wordUnitHeight + _spacing) - _spacing;
            var startY = totalHeight / 2f + containerY;
            var currentY = startY;

            foreach (var line in lines)
            {
                var totalWidth = 0f;
                foreach (var wordUnit in line)
                    totalWidth += wordUnit.ContainerSize.x;
                totalWidth += (line.Count - 1) * _spacing;

                var startX = -totalWidth / 2f + containerX;
                var currentX = startX;

                foreach (var wordUnit in line)
                {
                    var position = wordUnit.transform.position;
                    position.x = currentX + wordUnit.ContainerSize.x / 2f;
                    position.y = currentY - wordUnitHeight / 2f;

                    if (wordUnit == _addedWordUnit)
                        wordUnit.MoveToByDecreasing(position);
                    else
                        wordUnit.MoveTo(position);

                    currentX += wordUnit.ContainerSize.x + _spacing;
                }
                currentY -= wordUnitHeight + _spacing;
            }
        }
    }
}