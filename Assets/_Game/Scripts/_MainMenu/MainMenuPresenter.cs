using GameRoot;
using UnityEngine;
using R3;
using EncountersMap;

namespace MainMenu
{
    public class MainMenuPresenter
    {
        private MainMenuView _view;
        private MainMenuModel _model;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            _model = model;
            _view = view;

            _view.SetActiveContinueButton(_model.IsGameSessionStarted);

            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {
            _view.StartButtonPressedSignal
                .Subscribe(_ => OpenLevelMenu());

            _view.ContinueButtonPressedSignal
                .Subscribe(_ => ContinueLastGameSession());

            _view.AbilitiesButtonPressedSignal
                .Subscribe(_ => OpenAbilitiesMenu());

            _view.HeroesButtonPressedSignal
                .Subscribe(_ => OpenHeroesMenu());
        }

        private void OpenLevelMenu()
        {
            G.SceneProvider.OpenLevelMenu();
        }

        private void ContinueLastGameSession()
        {
            Random.InitState(G.GameSessionProvider.SessionData.Seed);

            if (!G.SessionData.IsInEncounter)
            {
                G.SceneProvider.OpenEncountersMap();
                return;
            }

            var encounterName = G.SessionData.CurrentEncounterName;
            var encounterNumber = G.SessionData.CurrentEncounterNumber;

            switch (encounterName)
            {
                case EncounterName.Combat:
                case EncounterName.EmergencyCombat:
                case EncounterName.BossCombat:
                    G.SceneProvider.OpenCombat(encounterName, encounterNumber);
                    break;
            }
        }

        private void OpenAbilitiesMenu()
        {
            G.SceneProvider.OpenAbilityMenu();
        }

        private void OpenHeroesMenu()
        {
            G.SceneProvider.OpenHeroMenu();
        }
    }
}