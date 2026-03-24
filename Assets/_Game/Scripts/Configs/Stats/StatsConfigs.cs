using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "StatsConfigs",
                     menuName = "Game Configs/Stats/New Stats Configs")]
    public class StatsConfigs : ScriptableObject
    {
        public ExperienceLevelData[] ExperienceLevelDatas;
    }

    [Serializable]
    public class ExperienceLevelData
    {
        public int Count;
    }
}