using EncountersMap;
using GameRoot;
using GameSession;
using UnityEngine;

namespace Combat
{
    public class CombatEnterParams : SceneEnterParams
    {
        public readonly EncounterName EncounterName;
        public readonly int EncounterNumber;

        public CombatEnterParams(EncounterName encounterName, int encounterNumber) : base(Scenes.COMBAT)
        {
            EncounterName = encounterName;
            EncounterNumber = encounterNumber;
        }
    }
}