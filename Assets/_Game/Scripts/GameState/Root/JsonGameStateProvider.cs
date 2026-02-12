using Configs;
using GameRoot;
using R3;
using System.IO;
using UnityEngine;

namespace GameState
{
    public class JsonGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = "GAME_STATE";

        private string _savePath;

        public GameState GameState { get; private set; }
        private GameState DefaultGameState => G.ConfigsProvider.GameConfigs.DefaultGameStateConfigs.State;

        public JsonGameStateProvider()
        {
            _savePath = GetPath();
        }

        public Observable<bool> LoadGameState()
        {
            try
            {
                if (!File.Exists(_savePath))
                {
                    GameState = CreateInitalGameState();
                    SaveGameState();
                }
                else
                {
                    var json = File.ReadAllText(_savePath);
                    GameState = JsonUtility.FromJson<GameState>(json);
                }

                return Observable.Return(GameState != null);
            }
            catch { return Observable.Return(false); }
        }

        public Observable<bool> SaveGameState()
        {
            try
            {
                var json = JsonUtility.ToJson(GameState, true);
                File.WriteAllText(_savePath, json);

                return Observable.Return(true);
            }
            catch { return Observable.Return(false); }
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateInitalGameState();
            return SaveGameState();
        }

        private GameState CreateInitalGameState()
        {
            return JsonUtility.FromJson<GameState>(JsonUtility.ToJson(DefaultGameState));
        }

        private string GetPath()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return Path.Combine (Application.persistentDataPath, $"{GAME_STATE_KEY}.json");
#else
            return Path.Combine(Application.dataPath, $"{GAME_STATE_KEY}.json");
#endif
        }
    }
}
