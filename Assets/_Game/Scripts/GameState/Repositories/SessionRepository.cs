using Gameplay;
using GameSession;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public class SessionRepository
    {
        private readonly IGameStateProvider _gameStateProvider;

        private SessionGameState State => _gameStateProvider.GameState.Session;

        public SessionRepository(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }

        public GameSessionData GetData()
        {
            return State.Data;
        }

        public void SetData(GameSessionData data)
        {
            State.Data = data;
            _gameStateProvider.SaveGameState();
        }
    }
}