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

        public DeckPopUp OpenDeckPopUp(IEnumerable<WordUnitConfigs> wordUnitConfigs)
        {
            var createdPopUp = _popUpFactory.Create(Configs.DeckPopUpPrefab);
            createdPopUp.Open(wordUnitConfigs);

            return createdPopUp;
        }

        public AbilitySelectionPopUp OpenAbilitySelectionPopUp()
        {
            var createdPopUp = _popUpFactory.Create(Configs.AbilitySelectionPopUpPrefab);
            createdPopUp.Open();

            return createdPopUp;
        }
    }
}