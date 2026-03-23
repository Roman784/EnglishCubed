using Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "StatLimitsConfigs",
                     menuName = "Game Configs/Stats/New Stat Limits Configs")]
    public class StatLimitsConfigs : ScriptableObject
    {
        public List<MaxStatData> Limits;

        public float GetMaxStatValue(StatName statName)
        {
            var maxStatData = Limits.FirstOrDefault(data => data.Name == statName);
            if (maxStatData == null) return 0f;
            return maxStatData.Value;
        }

#if UNITY_EDITOR
        [ContextMenu("Create Data")]
        private void CreateData()
        {
            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                if (Limits.Any(data => data.Name == statName)) continue;
                Limits.Add(new MaxStatData { Name = statName, Value = 0f });
            }
            EditorUtility.SetDirty(this);
        }
#endif
    }

    [Serializable]
    public class MaxStatData
    {
        public StatName Name;
        public float Value;
    }
}