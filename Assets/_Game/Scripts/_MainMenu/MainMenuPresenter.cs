using GameRoot;
using UnityEngine;
using R3;

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
            //G.SceneProvider.OpenLevelMenu();

            G.GameSessionProvider.StartNewSession(_model.SelectedHero);
            G.SceneProvider.OpenCombat(1); // TEMP
        }

        private void ContinueLastGameSession()
        {
            if (!G.SessionData.IsInEncounter)
            {
                G.SceneProvider.OpenEncountersMap();
                return;
            }

            var stageNumber = G.SessionData.CurrentEncounterNumber;
            G.SceneProvider.OpenCombat(stageNumber);
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