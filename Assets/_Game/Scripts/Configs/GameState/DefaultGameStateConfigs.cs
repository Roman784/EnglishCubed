using UnityEngine;
using State = GameState.GameState;

namespace Configs
{
    [CreateAssetMenu(
        fileName = "DefaultGameStateConfigs",
        menuName = "Game Configs/New Default Game State Configs",
        order = 100)]
    public class DefaultGameStateConfigs : ScriptableObject
    {
        public State State;
    }
}
