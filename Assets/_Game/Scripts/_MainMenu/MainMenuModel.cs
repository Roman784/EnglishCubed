using Gameplay;
using GameRoot;
using GameSession;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuModel
    {
        public bool IsGameSessionStarted => G.GameSessionProvider.IsSessionStarted;
        public CreatureName SelectedHero => G.Repository.MetaProgression.GetSelectedHero();

        public MainMenuModel()
        {
        }
    }
}