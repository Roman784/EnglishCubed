using Configs;
using EncountersMap;
using System.Collections.Generic;
using UnityEngine;

namespace GameProducer
{
    public class GameProducerContext
    {
        public LevelConfigs LevelConfigs;
        public EncounterName EncounterName;
        public int EncounterNumber;
        public int PassedEncountersCount;
        public int TotalEncountersCount;
        public List<WordUnitConfigs> LexiconPool;
        public List<AbilityConfigs> AbilitiesPool;

        public float PassedEncountersProgress => TotalEncountersCount > 0 ? 
            PassedEncountersCount / TotalEncountersCount : 0;
    }
}