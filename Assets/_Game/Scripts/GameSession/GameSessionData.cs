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
        public CreatureName Hero;
        public AcquiredAbilityData[] Abilities;
    }

    [Serializable]
    public class AcquiredAbilityData
    {
        public AbilityName Name;
        public int StacksCount;
    }
}