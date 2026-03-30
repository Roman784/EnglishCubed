using GameRoot;
using GameSession;
using UnityEngine;

namespace Combat
{
    public class CombatEnterParams : SceneEnterParams
    {
        public CombatEnterParams() : base(Scenes.COMBAT)
        {
        }
    }
}