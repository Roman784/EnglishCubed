using Configs;
using UnityEngine;

namespace Abilities
{
    public class AbilitySelectionData
    {
        public AbilityConfigs Configs;
        public int Level;

        public AbilityLevelData GetLevelData()
        {
            var index = Mathf.Clamp(Level, 0, Configs.Levels.Length - 1);
            return Configs.Levels[index];
        }
    }
}