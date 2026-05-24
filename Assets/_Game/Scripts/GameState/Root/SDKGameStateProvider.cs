using GameRoot;
using R3;
using SDK;
using UnityEngine;

namespace GameState
{
    public class SDKGameStateProvider : IGameStateProvider
    {
        public GameState GameState { get; private set; }
        private GameState DefaultGameState => G.ConfigsProvider.GameConfigs.DefaultGameStateConfigs.State;

        public Observable<bool> LoadGameState()
        {
            var onLoaded = new Subject<bool>();

            G.SDK.LoadData().Subscribe(res =>
            {
                if (res != "none")
                {
                    if (res == "" || res == "{}")
                    {
                        GameState = CreateInitalGameState();
                        SaveGameState();
                    }
                    else
                    {
                        GameState = JsonUtility.FromJson<GameState>(res);
                    }

                    onLoaded.OnNext(true);
                }
                else
                {
                    onLoaded.OnNext(false);
                }
            });

            return onLoaded;
        }

        public Observable<bool> SaveGameState()
        {
            try
            {
                var json = JsonUtility.ToJson(GameState, true);
                G.SDK.SaveData(json);

                return Observable.Return(true);
            }
            catch { return Observable.Return(false); }
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateInitalGameState();
            SaveGameState();

            return Observable.Return(true);
        }

        private GameState CreateInitalGameState()
        {
            return JsonUtility.FromJson<GameState>(JsonUtility.ToJson(DefaultGameState));
        }
    }
}
