using System;

namespace GameState
{
    [Serializable]
    public class GameState
    {
        public MetaProgressionGameState MetaProgression;
        public CurrencyGameState Currency;
        public SessionGameState Session;
        public AudioGameState Audio;
    }
}