using Audio;
using Configs;
using GameState;
using R3;
using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace GameRoot
{
    public sealed class GameEntryPoint : SceneEntryPoint<SceneEnterParams>
    {
        private void Start()
        {
            var enterParams = new SceneEnterParams(Scenes.BOOT);
            Coroutines.Start(Run(enterParams));
        }

        // Application initializing: loading data and setting up.
        protected override IEnumerator Run(SceneEnterParams _)
        {
            SetAppSettings();

            yield return null;

            G.ConfigsProvider = new ScriptableObjectConfigsProvider();
            var gameStateProvider = new JsonGameStateProvider();

            yield return HandleLoading(
                G.ConfigsProvider.LoadGameConfigs(),
                "Failed to load the game config!");

            yield return HandleLoading(
                gameStateProvider.LoadGameState(),
                "Failed to load game state!");

            G.Repository = new Repository(gameStateProvider);
            G.UIRoot = CreateUIRoot();
            G.SceneProvider = new SceneProvider(G.UIRoot);
            G.AudioProvider = new AudioProvider();

            StartGame();
        }

        private void SetAppSettings()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private IEnumerator HandleLoading(Observable<bool> loadingSignal, string exceptionMessage)
        {
            var isLoaded = false;
            loadingSignal.Subscribe(result =>
            {
                if (result)
                    isLoaded = true;
                else
                    throw new Exception(exceptionMessage);
            });
            yield return new WaitUntil(() => isLoaded);
        }

        private UIRoot CreateUIRoot()
        {
            var createdUIRoot = Instantiate(G.ConfigsProvider.GameConfigs.UIConfigs.Root);
            DontDestroyOnLoad(createdUIRoot.gameObject);
            return createdUIRoot;
        }

        // Starts the first scene the player will see.
        private void StartGame()
        {
#if UNITY_EDITOR
            var initialEditorScene = GameAutostarter.InitialEditorScene;

            if (initialEditorScene == Scenes.MAIN_MENU)
            {
                G.SceneProvider.OpenMainMenu();
                return;
            }

            else if (initialEditorScene == Scenes.LEVEL_MENU)
            {
                G.SceneProvider.OpenLevelMenu();
                return;
            }

            else if (initialEditorScene == Scenes.TEST_ROOM)
            {
                G.SceneProvider.OpenTestRoom();
                return;
            }

            // For an unregistered scene. For example, from assets.
            else if (initialEditorScene != Scenes.BOOT)
            {
                SceneManager.LoadScene(initialEditorScene);
                return;
            }
#endif

            G.SceneProvider.OpenMainMenu();
        }
    }
}