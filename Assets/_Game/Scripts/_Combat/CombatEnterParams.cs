using GameRoot;
using GameSession;
using UnityEngine;

namespace Combat
{
    public class CombatEnterParams : SceneEnterParams
    {
        public readonly int EncounterNumber;

        public CombatEnterParams(int encounterNumber) : base(Scenes.COMBAT)
        {
            EncounterNumber = encounterNumber;
        }
    }
}