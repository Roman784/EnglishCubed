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
        public AbilitySaveData[] Abilities = new AbilitySaveData[0];
    }
}