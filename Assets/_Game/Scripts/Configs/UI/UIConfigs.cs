using UI;
using UnityEngine;

namespace GameRoot
{
    [CreateAssetMenu(fileName = "UIConfigs",
                     menuName = "Game Configs/UI/New UI Configs")]
    public class UIConfigs : ScriptableObject
    {
        [Header("Root")]
        public UIRoot Root;

        [Header("PopUps Gameplay")]
        public SettingsPopUp SettingsPopUpPrefab;
        public DeckPopUp DeckPopUpPrefab;
        public AbilitySelectionPopUp AbilitySelectionPopUpPrefab;
        public WordUnitSelectionPopUp WordUnitSelectionPopUpPrefab;
        public CombatDefeatPopUp CombatDefeatPopUpPrefab;
        public CombatVictoryPopUp CombatVictoryPopUpPrefab;
    }
}
