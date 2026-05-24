using Abilities;
using Audio;
using Configs;
using Currency;
using GameSession;
using GameState;
using Localization;
using R3;
using SDK;
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

            SDK.SDK sdk = null;
#if !UNITY_EDITOR && UNITY_WEBGL
            sdk = new GameObject("SDK").AddComponent<YandexSDK>();
#else
            sdk = new GameObject("SDK").AddComponent<EditorSDK>();
#endif
            DontDestroyOnLoad(sdk);

            G.SDK = sdk;
            G.SDK.Init();

            G.ConfigsProvider = new ScriptableObjectConfigsProvider();

            IGameStateProvider gameStateProvider;
#if !UNITY_EDITOR && UNITY_WEBGL
            gameStateProvider = new SDKGameStateProvider();
#else
            gameStateProvider = new JsonGameStateProvider();
#endif
            G.LocalizationProvider = new JsonLocalizationProvider();

            yield return HandleLoading(
                G.ConfigsProvider.LoadGameConfigs(),
                "Failed to load the game config!");

            yield return HandleLoading(
                gameStateProvider.LoadGameState(),
                "Failed to load game state!");

            G.Repository = new Repository(gameStateProvider);

            yield return HandleLoading(
                G.LocalizationProvider.LoadTranslations(G.Repository.Language.GetLanguage()),
                "Failed to load localization configs!");

            G.UIRoot = CreateUIRoot();
            G.PopUpsProvider = new PopUpsProvider();
            G.SceneProvider = new SceneProvider(G.UIRoot);
            G.AudioProvider = new AudioProvider();
            G.Wallet = new Wallet();
            G.GameSessionProvider = new GameSessionProvider();
            G.AbilityProvider = new AbilityProvider();
            G.GameProducer = new GameProducer.GameProducer();

            yield return R.LoadAudioClips();

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

            if (initialEditorScene == Scenes.MAIN_MENU) { G.SceneProvider.OpenMainMenu(); return; }
            else if (initialEditorScene == Scenes.LEVEL_MENU) { G.SceneProvider.OpenLevelMenu(); return; }
            else if (initialEditorScene == Scenes.ABILITY_MENU) { G.SceneProvider.OpenAbilityMenu(); return; }
            else if (initialEditorScene == Scenes.HERO_MENU) { G.SceneProvider.OpenHeroMenu(); return; }
            else if (initialEditorScene == Scenes.TEST_ROOM) { G.SceneProvider.OpenTestRoom(); return; }
            else if (initialEditorScene == Scenes.ENCOUNTERS_MAP) { G.SceneProvider.OpenEncountersMap(); return; }
            else if (initialEditorScene == Scenes.COMBAT) 
            {
                var defaultGameSessionData = G.Configs.DefaultGameSessionDataConfigs.Data;
                G.GameSessionProvider.StartNewSession(defaultGameSessionData);
                G.SceneProvider.OpenCombat(
                    defaultGameSessionData.CurrentEncounterName, defaultGameSessionData.CurrentEncounterNumber);
                return; 
            }

            // For an unregistered scene. For example, from assets.
            else if (initialEditorScene != Scenes.BOOT) { SceneManager.LoadScene(initialEditorScene); return; }
#endif

            G.SceneProvider.OpenMainMenu();
        }
    }
}