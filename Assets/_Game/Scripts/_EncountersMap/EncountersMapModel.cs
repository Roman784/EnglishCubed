using System.Collections.Generic;
using UI;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapModel
    {
        public IEnumerable<int> PassedStages { get; private set; }
        public EncountersMapGenerator MapGenerator { get; private set; }
        public Vector2Int MapSize { get; private set; }
        public float SpacingBetweenEncounterButtons { get; private set; }

        public EncounterButton SelectedEncounterButton { get; set; }

        private Dictionary<EncounterNode, EncounterButton> _encounterButtonsMap = new();

        public IReadOnlyDictionary<EncounterNode, EncounterButton> EncounterButtonsMap => _encounterButtonsMap;

        public EncountersMapModel(
            IEnumerable<int> passedStages,
            EncountersMapGenerator mapGenerator,
            Vector2Int mapSize,
            float spacingBetweenEncounterButtons)
        {
            PassedStages = passedStages;
            MapGenerator = mapGenerator;
            MapSize = mapSize;
            SpacingBetweenEncounterButtons = spacingBetweenEncounterButtons;
        }

        public void AddEncounterButton(EncounterNode node, EncounterButton button)
        {
            _encounterButtonsMap.Add(node, button);
        }

        public IEnumerable<EncounterButton> GetLinkedEncounterButtons(EncounterNode node)
        {
            foreach (var linkedNode in node.LinkedNodes)
            {
                if (_encounterButtonsMap.TryGetValue(linkedNode, out var button))
                {
                    yield return button;
                }
            }
        }
    }
}