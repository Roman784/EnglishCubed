using Abilities;
using Gameplay;
using System;
using UnityEngine;

namespace GameState
{
    [Serializable]
    public class MetaProgressionGameState    
    {
        public CreatureName SelectedHero;
        public CreatureName[] UnlockedHeroes;
        public AbilityName[] UnlockedAbilities;
    }
}