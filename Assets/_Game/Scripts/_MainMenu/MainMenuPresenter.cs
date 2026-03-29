using GameRoot;
using UnityEngine;
using R3;

namespace MainMenu
{
    public class MainMenuPresenter
    {
        private MainMenuModel _model;
        private MainMenuView _view;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            _model = model;
            _view = view;

            _view.SetActiveContinueButton(false);

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
            G.SceneProvider.OpenCombat();
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