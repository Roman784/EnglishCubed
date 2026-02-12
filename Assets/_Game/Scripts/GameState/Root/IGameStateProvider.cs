using R3;

namespace GameState
{
    public interface IGameStateProvider
    {
        public GameState GameState { get; }

        public Observable<bool> LoadGameState();
        public Observable<bool> SaveGameState();
        public Observable<bool> ResetGameState();
    }
}
