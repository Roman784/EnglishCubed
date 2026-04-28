using EncountersMap;
using UnityEngine;

namespace GameProducer
{
    public class GameProducerContext
    {
        public EncounterName EncounterName;
        public int EncounterNumber;
        public int PassedEncountersCount;
        public int TotalEncountersCount;

        public float PassedEncountersProgress => TotalEncountersCount > 0 ? 
            PassedEncountersCount / TotalEncountersCount : 0;
    }
}