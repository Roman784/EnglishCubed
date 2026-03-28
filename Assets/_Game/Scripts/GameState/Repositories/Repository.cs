namespace GameState
{
    public class Repository
    {
        public readonly CurrencyRepository Currency;
        public readonly AudioRepository Audio;

        public Repository(IGameStateProvider gameStateProvider)
        {
            Currency = new CurrencyRepository(gameStateProvider);
            Audio = new AudioRepository(gameStateProvider);
        }
    }
}
