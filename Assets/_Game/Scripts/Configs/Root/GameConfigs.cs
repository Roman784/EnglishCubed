using GameRoot;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameConfigs", 
                     menuName = "Game Configs/New Game Configs", 
                     order = 0)]
    public class GameConfigs : ScriptableObject
    {
        public LexiconConfigs LexiconConfigs;
        public AudioConfigs AudioConfigs;
        public UIConfigs UIConfigs;
        public DefaultGameStateConfigs DefaultGameStateConfigs;
    }
}
