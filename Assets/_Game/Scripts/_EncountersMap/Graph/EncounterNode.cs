using System.Collections.Generic;
using UnityEngine;

namespace EncountersMap
{
    public class EncounterNode
    {
        private List<EncounterNode> _linkedNodes = new();

        public int LinkedNodesCount => _linkedNodes.Count;
        public IEnumerable<EncounterNode> LinkedNodes => _linkedNodes;

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