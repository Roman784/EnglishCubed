using System.Collections.Generic;
using UnityEngine;
using R3;

namespace Gameplay
{
    public class StatCellsView: MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private StatCellView _cellPrefab;

        private LinkedList<StatCellView> _cells;

        public void Init(Stat stat)
        {
            _cells = new LinkedList<StatCellView>();
            ClearContainer();

            stat.Current.Subscribe(current => UpdateCells(current, stat.Max));
        }

        private void UpdateCells(int fillsCount, int max)
        {
            if (_cells.Count > max)
                DestroyCells(_cells.Count - max);
            else if (_cells.Count < max)
                CreateCells(max - _cells.Count);

            int i = 0;
            foreach (var cell in _cells)
            {
                if (fillsCount > i)
                    cell.Fill();
                else
                    cell.Spend();
                i++;
            }
        }

        private void CreateCells(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var createdCell = Instantiate(_cellPrefab, _container, false);
                _cells.AddLast(createdCell);
            }
        }

        private void DestroyCells(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (_cells.Count == 0) return;

                var lastCell = _cells.Last.Value;
                _cells.RemoveLast();
                Destroy(lastCell.gameObject);
            }
        }

        private void ClearContainer()
        {
            var childCount = _container.childCount;
            for (int i = 0; i < childCount; i++)
                Destroy(_container.GetChild(i).gameObject);
        }
    }
}