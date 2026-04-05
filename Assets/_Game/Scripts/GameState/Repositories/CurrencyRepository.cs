using GameRoot;
using UnityEngine;

namespace GameState
{
    public class CurrencyRepository
    {
        private readonly IGameStateProvider _gameStateProvider;

        private CurrencyGameState State => _gameStateProvider.GameState.Currency;

        public CurrencyRepository(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }

        public int GetCoins()
        {
            return State.Coins;
        }

        public void SetCoins(int value)
        {
            State.Coins = value;
            _gameStateProvider.SaveGameState();
        }

        public void AddCoins(int value)
        {
            State.Coins += value;
            _gameStateProvider.SaveGameState();
        }
    }
}
