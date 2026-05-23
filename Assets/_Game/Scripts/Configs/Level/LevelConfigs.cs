using Gameplay;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelConfigs",
                     menuName = "Game Configs/Levels/LevelConfigs")]
    public class LevelConfigs : ScriptableObject
    {
        public Location LocationPrefab;
        public TheoryConfigs TheoryConfigs;
        public WordUnitConfigs[] LexiconPool;
        public AbilityConfigs[] AbilitiesPool;
        public AudioClip BackgroundMusic;
    }
}