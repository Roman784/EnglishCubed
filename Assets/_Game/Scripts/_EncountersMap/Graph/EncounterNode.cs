using System.Collections.Generic;
using UnityEngine;

namespace EncountersMap
{
    public class EncounterNode
    {
        private int _number;
        private List<EncounterNode> _linkedNodes = new();

        public int Number => _number;
        public IEnumerable<EncounterNode> LinkedNodes => _linkedNodes;
        public int LinkedNodesCount => _linkedNodes.Count;

        public void SetNumber(int number)
        {
            _number = number;
        }

        public bool IsLinked(EncounterNode node)
        {
            return _linkedNodes.Contains(node);
        }

        public void AddLinkedNode(EncounterNode node)
        {
            if (IsLinked(node) || node == this) return;
            _linkedNodes.Add(node);
        }
    }
}