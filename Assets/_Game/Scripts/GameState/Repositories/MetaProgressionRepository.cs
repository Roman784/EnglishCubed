using Abilities;
using Gameplay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameState
{
    public class MetaProgressionRepository    
    {
        private readonly IGameStateProvider _gameStateProvider;

        private MetaProgressionGameState State => _gameStateProvider.GameState.MetaProgression;

        public MetaProgressionRepository(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }

        public CreatureName GetSelectedHero()
        {
            return State.SelectedHero;
        }

        public IEnumerable<CreatureName> GetUnlockedHeroes()
        {
            return State.UnlockedHeroes;
        }

        public IEnumerable<AbilityName> GetUnlockedAbilities()
        {
            return State.UnlockedAbilities ?? new AbilityName[0];
        }

        public void SetSeletedhero(CreatureName name)
        {
            State.SelectedHero = name;
            _gameStateProvider.SaveGameState();
        }

        public void UnlockHero(CreatureName name)
        {
            if (!State.UnlockedHeroes.Contains(name))
            {
                var unlockedHeroes = State.UnlockedHeroes.ToList();
                unlockedHeroes.Add(name);
                State.UnlockedHeroes = unlockedHeroes.ToArray();

                _gameStateProvider.SaveGameState();
            }
        }

        public void UnlockAbility(AbilityName name)
        {
            if (!State.UnlockedAbilities.Contains(name))
            {
                var unlockedAbilities = State.UnlockedAbilities.ToList();
                unlockedAbilities.Add(name);
                State.UnlockedAbilities = unlockedAbilities.ToArray();
                _gameStateProvider.SaveGameState();
            }
        }
    }
}