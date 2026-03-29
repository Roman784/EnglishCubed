using System;

namespace GameState
{
    [Serializable]
    public class GameState
    {
        public MetaProgressionGameState MetaProgression;
        public CurrencyGameState Currency;
        public AudioGameState Audio;
    }
}