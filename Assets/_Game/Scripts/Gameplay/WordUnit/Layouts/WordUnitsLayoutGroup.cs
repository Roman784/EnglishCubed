using DG.Tweening;
using R3;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Gameplay
{
    public abstract class WordUnitsLayoutGroup : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField, Range(0f, 1f)] private float _spacing;
        [SerializeField, Range(0f, 1f)] private float _gravitationalPullerStrength;

        protected List<WordUnit> _allWordUnits = new();
        protected Dictionary<WordUnit, Vector2> _wordUnitPositionsMap = new();
        protected WordUnit _lastAddedWordUnit;
        private Dictionary<WordUnit, Vector3> _originalScales = new();

        private WordUnitsGravitationalPuller _gravitationalPuller;
        
        public WordUnitsGravitationalPuller GravitationalPuller => _gravitationalPuller;

        private Vector2 WordUnitSize(WordUnit wordUnit) => wordUnit.Transform.ContainerSize;

        protected abstract Tween Move(WordUnit wordUnit, Vector2 position);

        public virtual void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);
            _lastAddedWordUnit = wordUnit;
        }

        public virtual void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);
        }

        private void Awake()
        {
            _gravitationalPuller = new WordUnitsGravitationalPuller(
                _container, _allWordUnits, _gravitationalPullerStrength);
        }

        private void Update()
        {
            _gravitationalPuller.Handle();
        }

        [ContextMenu ("Arrange")]
        public Observable<WordUnit> Arrange()
        {
            if (_allWordUnits.Count == 0) return Observable.Never<WordUnit>();

            var wordUnitMovedSignal = new Subject<WordUnit>();
            var wordUnitPositionsMap = new Dictionary<WordUnit, Vector2>();

            var containerCorners = new Vector3[4];
            _container.GetWorldCorners(containerCorners);

            var minScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);
            var containerWidth = maxScreenContainerCorner.x - minScreenContainerCorner.x;
            var containerHeight = maxScreenContainerCorner.y - minScreenContainerCorner.y;

            // Сначала определим базовый размер объектов
            var baseSizes = new Dictionary<WordUnit, Vector2>();
            foreach (var wordUnit in _allWordUnits)
                baseSizes[wordUnit] = WordUnitSize(wordUnit);

            // Рассчитаем оптимальный масштаб
            var scale = CalculateOptimalScale(_allWordUnits.ToList(), baseSizes, containerWidth, containerHeight);

            // Перераспределяем объекты по строкам с учетом масштаба
            var lines = CreateLinesWithScale(_allWordUnits, baseSizes, containerWidth, scale);

            // Позиционируем с учетом масштаба
            var wordUnitsAndPositionsPair = CenterLinesWithScale(
                lines, minScreenContainerCorner, maxScreenContainerCorner, baseSizes, scale, wordUnitMovedSignal);

            foreach (var pair in wordUnitsAndPositionsPair)
                wordUnitPositionsMap[pair.Item1] = pair.Item2;

            _lastAddedWordUnit = null;
            _wordUnitPositionsMap = wordUnitPositionsMap;

            return wordUnitMovedSignal;
        }

        private float CalculateOptimalScale(List<WordUnit> wordUnits, Dictionary<WordUnit, Vector2> baseSizes,
            float containerWidth, float containerHeight)
        {
            float minScale = 0.3f; // Минимальный допустимый масштаб
            float maxScale = 1f;   // Максимальный масштаб (оригинальный размер)
            float optimalScale = 1f;

            // Пробуем разные масштабы, пока не найдем оптимальный
            for (float testScale = maxScale; testScale >= minScale; testScale -= 0.05f)
            {
                var lines = new List<List<WordUnit>>();
                var currentLine = new List<WordUnit>();
                var currentLineWidth = 0f;

                foreach (var wordUnit in wordUnits)
                {
                    var scaledWidth = baseSizes[wordUnit].x * testScale;

                    if (currentLine.Count > 0 && currentLineWidth + scaledWidth + _spacing * testScale > containerWidth)
                    {
                        lines.Add(new List<WordUnit>(currentLine));
                        currentLine.Clear();
                        currentLineWidth = 0;
                    }

                    currentLine.Add(wordUnit);
                    currentLineWidth += scaledWidth + (currentLine.Count > 1 ? _spacing * testScale : 0);
                }

                if (currentLine.Count > 0)
                    lines.Add(new List<WordUnit>(currentLine));

                // Проверяем, помещается ли по высоте
                var wordUnitHeight = baseSizes[wordUnits[0]].y * testScale;
                var requiredHeight = lines.Count * (wordUnitHeight + _spacing * testScale) - _spacing * testScale;

                if (requiredHeight <= containerHeight)
                {
                    optimalScale = testScale;
                    break;
                }
            }

            return optimalScale;
        }

        private List<List<WordUnit>> CreateLinesWithScale(IEnumerable<WordUnit> wordUnits,
            Dictionary<WordUnit, Vector2> baseSizes, float containerWidth, float scale)
        {
            var lines = new List<List<WordUnit>>();
            var currentLine = new List<WordUnit>();
            var currentLineWidth = 0f;
            var scaledSpacing = _spacing * scale;

            foreach (var wordUnit in wordUnits)
            {
                var scaledWidth = baseSizes[wordUnit].x * scale;

                // Проверяем, помещается ли элемент в текущую строку с учетом масштаба
                if (currentLine.Count == 0 || currentLineWidth + scaledWidth + scaledSpacing <= containerWidth)
                {
                    currentLine.Add(wordUnit);
                    currentLineWidth += scaledWidth + (currentLine.Count > 1 ? scaledSpacing : 0);
                }
                else
                {
                    // Начинаем новую строку
                    lines.Add(new List<WordUnit>(currentLine));
                    currentLine.Clear();
                    currentLine.Add(wordUnit);
                    currentLineWidth = scaledWidth;
                }
            }

            if (currentLine.Count > 0)
                lines.Add(new List<WordUnit>(currentLine));

            return lines;
        }

        private List<(WordUnit, Vector2)> CenterLinesWithScale(List<List<WordUnit>> lines,
            Vector2 minContainerCorner, Vector2 maxContainerCorner,
            Dictionary<WordUnit, Vector2> baseSizes, float scale,
            Subject<WordUnit> wordUnitMovedSignal)
        {
            if (lines.Count == 0) return null;

            var wordUnitsAndPositionsPair = new List<(WordUnit, Vector2)>();

            var containerCenter = (minContainerCorner + maxContainerCorner) / 2f;
            var scaledSpacing = _spacing * scale;

            // Вычисляем общую высоту всех строк
            var wordUnitHeight = baseSizes[lines[0][0]].y * scale;
            var totalHeight = lines.Count * (wordUnitHeight + scaledSpacing) - scaledSpacing;
            var startY = containerCenter.y + totalHeight / 2f;
            var currentY = startY;

            foreach (var line in lines)
            {
                // Вычисляем общую ширину строки
                var totalWidth = 0f;
                foreach (var wordUnit in line)
                    totalWidth += baseSizes[wordUnit].x * scale;
                totalWidth += (line.Count - 1) * scaledSpacing;

                var startX = containerCenter.x - totalWidth / 2f;
                var currentX = startX;

                foreach (var wordUnit in line)
                {
                    var scaledSize = baseSizes[wordUnit] * scale;
                    var position = new Vector2(
                        currentX + scaledSize.x / 2f,
                        currentY - wordUnitHeight / 2f
                    );

                    wordUnitsAndPositionsPair.Add((wordUnit, position));

                    // Применяем масштаб к объекту
                    ApplyScaleToWordUnit(wordUnit, scale);

                    if (wordUnit.Position != position)
                        Move(wordUnit, position).OnComplete(() =>
                        {
                            wordUnitMovedSignal.OnNext(wordUnit);
                            if (wordUnit == _allWordUnits.LastOrDefault())
                                wordUnitMovedSignal.OnCompleted();
                        });

                    currentX += scaledSize.x + scaledSpacing;
                }
                currentY -= wordUnitHeight + scaledSpacing;
            }

            return wordUnitsAndPositionsPair;
        }

        private void ApplyScaleToWordUnit(WordUnit wordUnit, float scale)
        {
            wordUnit.transform.localScale = Vector3.one * scale;

            if (!_originalScales.ContainsKey(wordUnit))
                _originalScales[wordUnit] = Vector3.one;
        }
    }
}