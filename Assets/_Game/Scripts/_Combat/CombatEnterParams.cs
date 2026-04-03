using GameRoot;
using GameSession;
using UnityEngine;

namespace Combat
{
    public class CombatEnterParams : SceneEnterParams
    {
        public readonly int StageNumber;

        public CombatEnterParams(int stageNumber) : base(Scenes.COMBAT)
        {
            StageNumber = stageNumber;
        }
    }
}