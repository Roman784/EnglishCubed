using Abilities;
using Gameplay;
using System;
using UnityEngine;

namespace GameSession
{
    [Serializable]
    public class GameSessionData
    {
        public bool IsStarted;
        public int StageNumber;
        public int[] PassedStages;
        public CreatureName Hero;
        public AbilitySaveData[] Abilities;
        public StatData[] Stats;
        public ExperienceSaveData Experience;
    }
}