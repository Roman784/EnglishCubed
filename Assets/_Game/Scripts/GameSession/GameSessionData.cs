using Abilities;
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
        public int CurrentEncounterNumber;
        public int[] PassedEncounters;
        public CreatureName Hero;
        public LevelName Level;
        public AbilitySaveData[] Abilities;
        public StatData[] Stats;
        public ExperienceSaveData Experience;
    }
}