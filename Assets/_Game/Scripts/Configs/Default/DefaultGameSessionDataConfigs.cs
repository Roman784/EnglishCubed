using GameSession;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(
        fileName = "DefaultGameSessionDataConfigs",
        menuName = "Game Configs/Default/New Default Game Session Configs",
        order = 101)]
    public class DefaultGameSessionDataConfigs: ScriptableObject
    {
        public GameSessionData Data;
    }
}