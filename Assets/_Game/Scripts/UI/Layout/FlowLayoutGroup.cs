using DG.Tweening;
using R3;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public abstract class FlowLayoutGroup : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField, Range(0f, 1f)] private float _spacing;
        [SerializeField, Range(0f, 1f)] private float _gravitationalPullerStrength;

        protected List<ILayoutElement> _allElements = new();
        protected Dictionary<ILayoutElement, Vector2> _elementPositionsMap = new();
        protected ILayoutElement _lastAddedElement;
        private Dictionary<ILayoutElement, Vector3> _originalScales = new();

        private GravitationalPuller _gravitationalPuller;

        public GravitationalPuller GravitationalPuller => _gravitationalPuller;

        protected abstract Tween Move(ILayoutElement element, Vector2 position);

        public virtual void Add(ILayoutElement element)
        {
            _allElements.Add(element);
            _lastAddedElement = element;
        }

        public virtual void Remove(ILayoutElement element)
        {
            _allElements.Remove(element);
        }

        private void Awake()
        {
            _gravitationalPuller = new GravitationalPuller(
                _container, _allElements, _gravitationalPullerStrength);
        }

        private void Update()
        {
            _gravitationalPuller.Handle();
        }

        [ContextMenu("Arrange")]
        public Observable<ILayoutElement> Arrange()
        {
            if (_allElements.Count == 0) return Observable.Never<ILayoutElement>();

            var elementMovedSignal = new Subject<ILayoutElement>();
            var elementPositionsMap = new Dictionary<ILayoutElement, Vector2>();

            var containerCorners = new Vector3[4];
            _container.GetWorldCorners(containerCorners);

            var minScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);
            var containerWidth = maxScreenContainerCorner.x - minScreenContainerCorner.x;
            var containerHeight = maxScreenContainerCorner.y - minScreenContainerCorner.y;

            var baseSizes = new Dictionary<ILayoutElement, Vector2>();
            foreach (var element in _allElements)
                baseSizes[element] = element.ContainerSize;

            var scale = CalculateOptimalScale(_allElements.ToList(), baseSizes, containerWidth, containerHeight);
            var lines = CreateLinesWithScale(_allElements, baseSizes, containerWidth, scale);
            var elementsAndPositionsPair = CenterLinesWithScale(
                lines, minScreenContainerCorner, maxScreenContainerCorner, baseSizes, scale, elementMovedSignal);

            foreach (var pair in elementsAndPositionsPair)
                elementPositionsMap[pair.Item1] = pair.Item2;

            _lastAddedElement = null;
            _elementPositionsMap = elementPositionsMap;

            return elementMovedSignal;
        }

        private float CalculateOptimalScale(List<ILayoutElement> elements,
            Dictionary<ILayoutElement, Vector2> baseSizes,
            float containerWidth, float containerHeight)
        {
            float minScale = 0.3f;
            float maxScale = 1f;
            float optimalScale = 1f;

            for (float testScale = maxScale; testScale >= minScale; testScale -= 0.05f)
            {
                var lines = new List<List<ILayoutElement>>();
                var currentLine = new List<ILayoutElement>();
                var currentLineWidth = 0f;

                foreach (var element in elements)
                {
                    var scaledWidth = baseSizes[element].x * testScale;

                    if (currentLine.Count > 0 && currentLineWidth + scaledWidth + _spacing * testScale > containerWidth)
                    {
                        lines.Add(new List<ILayoutElement>(currentLine));
                        currentLine.Clear();
                        currentLineWidth = 0;
                    }

                    currentLine.Add(element);
                    currentLineWidth += scaledWidth + (currentLine.Count > 1 ? _spacing * testScale : 0);
                }

                if (currentLine.Count > 0)
                    lines.Add(new List<ILayoutElement>(currentLine));

                var elementHeight = baseSizes[elements[0]].y * testScale;
                var requiredHeight = lines.Count * (elementHeight + _spacing * testScale) - _spacing * testScale;

                if (requiredHeight <= containerHeight)
                {
                    optimalScale = testScale;
                    break;
                }
            }

            return optimalScale;
        }

        private List<List<ILayoutElement>> CreateLinesWithScale(IEnumerable<ILayoutElement> elements,
            Dictionary<ILayoutElement, Vector2> baseSizes, float containerWidth, float scale)
        {
            var lines = new List<List<ILayoutElement>>();
            var currentLine = new List<ILayoutElement>();
            var currentLineWidth = 0f;
            var scaledSpacing = _spacing * scale;

            foreach (var element in elements)
            {
                var scaledWidth = baseSizes[element].x * scale;

                if (currentLine.Count == 0 || currentLineWidth + scaledWidth + scaledSpacing <= containerWidth)
                {
                    currentLine.Add(element);
                    currentLineWidth += scaledWidth + (currentLine.Count > 1 ? scaledSpacing : 0);
                }
                else
                {
                    lines.Add(new List<ILayoutElement>(currentLine));
                    currentLine.Clear();
                    currentLine.Add(element);
                    currentLineWidth = scaledWidth;
                }
            }

            if (currentLine.Count > 0)
                lines.Add(new List<ILayoutElement>(currentLine));

            return lines;
        }

        private List<(ILayoutElement, Vector2)> CenterLinesWithScale(List<List<ILayoutElement>> lines,
            Vector2 minContainerCorner, Vector2 maxContainerCorner,
            Dictionary<ILayoutElement, Vector2> baseSizes, float scale,
            Subject<ILayoutElement> elementMovedSignal)
        {
            if (lines.Count == 0) return null;

            var elementsAndPositionsPair = new List<(ILayoutElement, Vector2)>();

            var containerCenter = (minContainerCorner + maxContainerCorner) / 2f;
            var scaledSpacing = _spacing * scale;

            var elementHeight = baseSizes[lines[0][0]].y * scale;
            var totalHeight = lines.Count * (elementHeight + scaledSpacing) - scaledSpacing;
            var startY = containerCenter.y + totalHeight / 2f;
            var currentY = startY;

            foreach (var line in lines)
            {
                var totalWidth = 0f;
                foreach (var element in line)
                    totalWidth += baseSizes[element].x * scale;
                totalWidth += (line.Count - 1) * scaledSpacing;

                var startX = containerCenter.x - totalWidth / 2f;
                var currentX = startX;

                foreach (var element in line)
                {
                    var scaledSize = baseSizes[element] * scale;
                    var position = new Vector2(
                        currentX + scaledSize.x / 2f,
                        currentY - elementHeight / 2f
                    );

                    elementsAndPositionsPair.Add((element, position));

                    ApplyScaleToElement(element, scale);

                    if (element.Position != position)
                        Move(element, position).OnComplete(() =>
                        {
                            elementMovedSignal.OnNext(element);
                            if (element == _allElements.LastOrDefault())
                                elementMovedSignal.OnCompleted();
                        });

                    currentX += scaledSize.x + scaledSpacing;
                }
                currentY -= elementHeight + scaledSpacing;
            }

            return elementsAndPositionsPair;
        }

        private void ApplyScaleToElement(ILayoutElement element, float scale)
        {
            element.Transform.localScale = Vector3.one * scale;

            if (!_originalScales.ContainsKey(element))
                _originalScales[element] = Vector3.one;
        }
    }
}