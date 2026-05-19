using LevelMenu;
using System;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelsConfigs",
                     menuName = "Game Configs/Levels/LevelsConfigs")]
    public class LevelsConfigs : ScriptableObject
    {
        public LevelConfigsByLevelName[] AllLevelsConfigs;

        public LevelConfigs GetLevelConfigs(LevelName levelName) => 
            AllLevelsConfigs.FirstOrDefault(c => c.Name == levelName).Configs;
    }

    [Serializable]
    public class LevelConfigsByLevelName
    {
        public LevelName Name;
        public LevelConfigs Configs;
    }
}