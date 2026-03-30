namespace GameState
{
    public class Repository
    {
        public readonly MetaProgressionRepository MetaProgression;
        public readonly CurrencyRepository Currency;
        public readonly SessionRepository Session;
        public readonly AudioRepository Audio;

        public Repository(IGameStateProvider gameStateProvider)
        {
            MetaProgression = new MetaProgressionRepository(gameStateProvider);
            Currency = new CurrencyRepository(gameStateProvider);
            Session = new SessionRepository(gameStateProvider);
            Audio = new AudioRepository(gameStateProvider);
        }
    }
}
