using EncountersMap;
using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EncountersConfigs",
                     menuName = "Game Configs/Encounters/New Encounters Configs",
                     order = 0)]
    public class EncountersConfigs : ScriptableObject
    {
        public EncounterConfigs[] AllEncountersConfigs;
    }

    [Serializable]
    public class EncounterConfigs
    {
        public EncounterName Name;
        public int Weight;
    }
}