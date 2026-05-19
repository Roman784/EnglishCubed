using Abilities;
using Configs;
using GameRoot;
using System.Collections.Generic;

namespace UI
{
    public class PopUpsProvider
    {
        private PopUpFactory _popUpFactory;

        private UIConfigs Configs => G.ConfigsProvider.GameConfigs.UIConfigs;

        public PopUpsProvider()
        {
            _popUpFactory = new PopUpFactory();
        }

        public SettingsPopUp OpenSettingsPopUp(bool activeMainMenuButton)
        {
            var createdPopUp = _popUpFactory.Create(Configs.SettingsPopUpPrefab);
            createdPopUp.Open(activeMainMenuButton);

            return createdPopUp;
        }

        public TheoryPopUp OpenTheoryPopUp(string title, string content)
        {
            var createdPopUp = _popUpFactory.Create(Configs.TheoryPopUpPrefab);
            createdPopUp.Open(title, content);

            return createdPopUp;
        }

        public DeckPopUp OpenDeckPopUp(IEnumerable<WordUnitConfigs> wordUnitConfigs)
        {
            var createdPopUp = _popUpFactory.Create(Configs.DeckPopUpPrefab);
            createdPopUp.Open(wordUnitConfigs);

            return createdPopUp;
        }

        public AbilitySelectionPopUp OpenAbilitySelectionPopUp(IEnumerable<AbilitySelectionData> abilitiesConfigs)
        {
            var createdPopUp = _popUpFactory.Create(Configs.AbilitySelectionPopUpPrefab);
            createdPopUp.Open(abilitiesConfigs);

            return createdPopUp;
        }

        public WordUnitSelectionPopUp OpenWordUnitSelectionPopUp(IEnumerable<WordUnitConfigs> wordUnitConfigs)
        {
            var createdPopUp = _popUpFactory.Create(Configs.WordUnitSelectionPopUpPrefab);
            createdPopUp.Open(wordUnitConfigs);
            return createdPopUp;
        }

        public CombatDefeatPopUp OpenCombatDefeatPopUp()
        {
            var createdPopUp = _popUpFactory.Create(Configs.CombatDefeatPopUpPrefab);
            createdPopUp.Open();
            return createdPopUp;
        }

        public CombatVictoryPopUp OpenCombatVictoryPopUp(int earnedСoins, bool isLastEncounter)
        {
            var createdPopUp = _popUpFactory.Create(Configs.CombatVictoryPopUpPrefab);
            createdPopUp.Open(earnedСoins, isLastEncounter);
            return createdPopUp;
        }
    }
}