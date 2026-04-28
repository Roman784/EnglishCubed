using Abilities;
using EncountersMap;
using Gameplay;
using LevelMenu;
using System;
using UnityEngine;

namespace GameSession
{
    [Serializable]
    public class GameSessionData
    {
        public bool IsStarted;
        public int Seed;
        public bool IsInEncounter;
        public EncounterName CurrentEncounterName;
        public int CurrentEncounterNumber;
        public int TotalEncountersCount;
        public int[] PassedEncounters;
        public CreatureName Hero;
        public LevelName Level;
        public bool IsEnemyExist;
        public CreatureName Enemy;
        public int CurrentEnemyHealth;
        public int MaxEnemyHealth;
        public AbilitySaveData[] Abilities;
        public StatData[] Stats;
        public ExperienceSaveData Experience;
    }
}