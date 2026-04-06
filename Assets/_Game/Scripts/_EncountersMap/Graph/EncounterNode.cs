using System.Collections.Generic;
using UnityEngine;

namespace EncountersMap
{
    public class EncounterNode
    {
        private int _stageNumber;
        private List<EncounterNode> _linkedNodes = new();

        public int StageNumber => _stageNumber;
        public IEnumerable<EncounterNode> LinkedNodes => _linkedNodes;
        public int LinkedNodesCount => _linkedNodes.Count;

        public void SetStageNumber(int number)
        {
            _stageNumber = number;
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