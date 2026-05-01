using Abilities;
using EncountersMap;
using Gameplay;
using LevelMenu;
using System;
using System.Collections.Generic;
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
        public List<int> PassedEncounters;
        public CreatureName Hero;
        public LevelName Level;
        public bool IsEnemyExist;
        public CreatureName Enemy;
        public int CurrentEnemyHealth;
        public int MaxEnemyHealth;
        public List<AbilitySaveData> Abilities;
        public List<StatData> Stats;
        public ExperienceSaveData Experience;
        public List<string> WordsInHand;
        public List<string> WordsInDeck;
    }
}