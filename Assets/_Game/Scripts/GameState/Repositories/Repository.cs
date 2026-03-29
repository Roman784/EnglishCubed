namespace GameState
{
    public class Repository
    {
        public readonly MetaProgressionRepository MetaProgression;
        public readonly CurrencyRepository Currency;
        public readonly AudioRepository Audio;

        public Repository(IGameStateProvider gameStateProvider)
        {
            MetaProgression = new MetaProgressionRepository(gameStateProvider);
            Currency = new CurrencyRepository(gameStateProvider);
            Audio = new AudioRepository(gameStateProvider);
        }
    }
}
