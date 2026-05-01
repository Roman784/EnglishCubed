using Localization;
using UnityEngine;

namespace GameState
{
    public class LanguageRepository
    {
        private readonly IGameStateProvider _gameStateProvider;

        private LanguageState State => _gameStateProvider.GameState.Language;

        public LanguageRepository(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }

        public Language GetLanguage()
        {
            return State.Language;
        }

        public void SetLanguage(Language language)
        {
            State.Language = language;
            _gameStateProvider.SaveGameState();
        }
    }
}