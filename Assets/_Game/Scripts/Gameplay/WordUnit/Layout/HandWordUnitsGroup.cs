using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(HandFlowLayout))]
    public class HandWordUnitsGroup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _capacityView;
        [SerializeField] private TMP_Text _drawingPointsCountView;

        private List<WordUnit> _allWordUnits = new();
        private Dictionary<WordUnit, WordUnitBackplate> _backplatesMap = new();
        private List<WordUnitBackplate> _backplatesForDestruction = new();

        private int _maxCapacity;
        private int _drawingPointsCount;
        private HandFlowLayout _layout;

        public int CapacityLeft => _maxCapacity - CurrentCapacity;
        public HandFlowLayout Layout => _layout;
        public IEnumerable<WordUnit> AllWordUnits => _allWordUnits;
        private int CurrentCapacity => _layout.AllElementsCount;
        public int DrawingPointsCount => _drawingPointsCount;

        private void Awake()
        {
            _layout = GetComponent<HandFlowLayout>();
        }

        public void SetInitialWordUnits(IEnumerable<WordUnit> wordUnits, bool instantly = false)
        {
            _allWordUnits = new List<WordUnit>(wordUnits);
            _layout.SetInitialElements(wordUnits.Select(w => w.Transform), instantly);
        }

        public void SetMaxCapacity(int capacity)
        {
            _maxCapacity = capacity;
            UpdateCapacityView();
        }

        public void SetDrawingPointsCount(int count)
        {
            _drawingPointsCount = count;
            UpdateDrawingPointsView();
        }

        public void SpendDrawingPoint()
        {
            _drawingPointsCount -= 1;
            UpdateDrawingPointsView();
        }

        public bool CanAdd(WordUnit wordUnit) => CapacityLeft > 0 || _backplatesMap.ContainsKey(wordUnit);
        public bool CanRemove(WordUnit wordUnit) => _allWordUnits.Contains(wordUnit);

        public void Add(WordUnit wordUnit)
        {
            _allWordUnits.Add(wordUnit);

            if (_backplatesMap.TryGetValue(wordUnit, out var backplate) &&
                _layout.Contains(backplate))
            {
                var idx = _layout.IndexOf(backplate);
                _layout.Insert(idx, wordUnit.Transform);
                _layout.Remove(backplate);
                _backplatesMap.Remove(wordUnit);
                _backplatesForDestruction.Add(backplate);
                return;
            }

            _layout.Add(wordUnit.Transform);

            UpdateCapacityView();
        }

        public void Remove(WordUnit wordUnit)
        {
            _allWordUnits.Remove(wordUnit);

            var createdBackplate = Object.Instantiate(wordUnit.BackplatePrefab);
            createdBackplate.SetSize(wordUnit.Transform.ContainerSize);
            createdBackplate.transform.position = wordUnit.Transform.Position;
            _backplatesMap[wordUnit] = createdBackplate;

            var idx = _layout.IndexOf(wordUnit.Transform);
            _layout.Insert(idx, createdBackplate);
            _layout.Remove(wordUnit.Transform);
            
            UpdateCapacityView();
        }

        public void DestroyLinkedBackplates(IEnumerable<WordUnit> wordUnits)
        {
            foreach (var wordUnit in wordUnits)
            {
                if (_backplatesMap.TryGetValue(wordUnit, out var backplate))
                    _backplatesForDestruction.Add(backplate);
            }
            DestroyBackplates();
        }

        public void DestroyBackplates()
        {
            if (_backplatesForDestruction.Count == 0) return;

            _backplatesMap = _backplatesMap
                .Where(x => !_backplatesForDestruction.Contains(x.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var backplate in _backplatesForDestruction)
            {
                _layout.Remove(backplate);
                backplate.Destroy();
            }

            _backplatesForDestruction.Clear();

            UpdateCapacityView();
        }

        private void UpdateCapacityView()
        {
            _capacityView.text = $"Слов: {CurrentCapacity}/{_maxCapacity}";
        }

        private void UpdateDrawingPointsView()
        {
            _drawingPointsCountView.text = $"x{_drawingPointsCount}";
        }
    }
}