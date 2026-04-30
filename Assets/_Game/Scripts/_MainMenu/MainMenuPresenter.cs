using EncountersMap;
using GameRoot;
using R3;
using System;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuPresenter
    {
        private MainMenuView _view;
        private MainMenuModel _model;

        private CompositeDisposable _disposables = new();

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            _model = model;
            _view = view;

            _view.SetActiveContinueButton(_model.IsGameSessionStarted);

            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {
            _view.SettingsButtonPressedSignal
                .Subscribe(_ => HandleSettings())
                .AddTo(_disposables);

            _view.StartButtonPressedSignal
                .Subscribe(_ => OpenLevelMenu())
                .AddTo(_disposables);

            _view.ContinueButtonPressedSignal
                .Subscribe(_ => ContinueLastGameSession())
                .AddTo(_disposables);

            _view.AbilitiesButtonPressedSignal
                .Subscribe(_ => OpenAbilitiesMenu())
                .AddTo(_disposables);

            _view.HeroesButtonPressedSignal
                .Subscribe(_ => OpenHeroesMenu())
                .AddTo(_disposables);
        }

        private void OpenLevelMenu()
        {
            G.SceneProvider.OpenLevelMenu();
        }

        private void ContinueLastGameSession()
        {
            UnityEngine.Random.InitState(G.GameSessionProvider.SessionData.Seed);

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

        private void HandleSettings()
        {
            G.PopUpsProvider.OpenSettingsPopUp(false);
        }
    }
}