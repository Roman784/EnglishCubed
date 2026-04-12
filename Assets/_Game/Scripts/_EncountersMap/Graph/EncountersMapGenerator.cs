using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapGenerator
    {
        private Dictionary<Vector2Int, EncounterNode> _encountersMap;
        private Vector2Int _minCoordinates;
        private Vector2Int _maxCoordinates;

        private Vector2Int[] _nodeLinkDirections = new Vector2Int[4]
        {
            Vector2Int.up, Vector2Int.down, 
            Vector2Int.left, Vector2Int.right
        };

        public IReadOnlyDictionary<Vector2Int, EncounterNode> EncountersMap => _encountersMap;
        public int NodesCount => _encountersMap.Count;

        public EncountersMapGenerator()
        {
            _encountersMap = new Dictionary<Vector2Int, EncounterNode>();
        }

        public void GenerateMap(Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    var node = new EncounterNode();
                    _encountersMap.Add(new Vector2Int(x, y), node);

                    _minCoordinates = Vector2Int.Min(_minCoordinates, new Vector2Int(x, y));
                    _maxCoordinates = Vector2Int.Max(_maxCoordinates, new Vector2Int(x, y));
                }
            }
        }

        public void CreateLinks()
        {
            foreach (var node in _encountersMap)
            {
                _nodeLinkDirections = _nodeLinkDirections.OrderBy(_ => Random.value).ToArray();
                foreach (var linkDirection in _nodeLinkDirections)
                {
                    if (node.Value.LinkedNodesCount >= 1)
                        if (Random.Range(0, 100) > 50) continue;

                    var linkedNodePosition = node.Key + linkDirection;
                    if (_encountersMap.TryGetValue(linkedNodePosition, out var linkedNode) &&
                        !node.Value.IsLinked(linkedNode) &&
                        !linkedNode.IsLinked(node.Value))
                    {
                        node.Value.AddLinkedNode(linkedNode);
                        linkedNode.AddLinkedNode(node.Value);
                    }
                }
            }
        }

        public EncounterNode GetCenterNode()
        {
            return _encountersMap[GetCenterCoordinates()];
        }

        public Vector2Int GetCenterCoordinates()
        {
            return (_maxCoordinates - _minCoordinates) / 2;
        }

        public void SetStageNumbers()
        {
            int number = 1;
            foreach (var node in _encountersMap)
            {
                node.Value.SetNumber(number);
                number++;
            }
        }

        public IEnumerable<EncounterNode> GetEdgeNodes()
        {
            foreach (var kvp in _encountersMap)
            {
                var coordinates = kvp.Key;
                if (coordinates.x == _minCoordinates.x || coordinates.x == _maxCoordinates.x ||
                    coordinates.y == _minCoordinates.y || coordinates.y == _maxCoordinates.y)
                {
                    yield return kvp.Value;
                }
            }
        }
    }
}