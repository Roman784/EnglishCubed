using GameRoot;
using UnityEngine;
using R3;

namespace LevelMenu
{
    public class LevelMenuPresenter
    {
        private LevelMenuView _view;
        private LevelMenuModel _model;

        public LevelMenuPresenter(
            LevelMenuView view,
            LevelMenuModel model) 
        { 
            _view = view;
            _model = model;

            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {
            _view.LevelButtonPressedSignal
                .Subscribe(levelName => OpenLevel(levelName));

            _view.ExitButtonPressedSignal
                .Subscribe(_ => ExitFromMenu());
        }

        private void OpenLevel(LevelName level)
        {
            G.GameSessionProvider.StartNewSession(_model.SelectedHero, level);
            Random.InitState(G.GameSessionProvider.SessionData.Seed);
            G.SceneProvider.OpenEncountersMap();
        }

        private void ExitFromMenu()
        {
            G.SceneProvider.OpenMainMenu();
        }
    }
}