using Gameplay;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MaxStatsConfigs",
                     menuName = "Game Configs/Stats/New Max Stats Configs")]
    public class MaxStatsConfigs : ScriptableObject
    {
        public class MaxStatData
        {
            public StatName Name;
            public float Value;
        }

        public MaxStatData[] MaxStatsData;

        public float GetMaxStatValue(StatName statName)
        {
            var maxStatData = MaxStatsData.FirstOrDefault(data => data.Name == statName);
            if (maxStatData == null) return 0f;
            return maxStatData.Value;
        }
    }
}