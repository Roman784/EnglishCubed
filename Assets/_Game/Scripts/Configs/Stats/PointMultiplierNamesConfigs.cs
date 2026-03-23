using Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PointMultiplierNamesConfigs",
                     menuName = "Game Configs/Stats/New Point Multiplier Names Configs")]
    public class PointMultiplierNamesConfigs : ScriptableObject
    {
        public List<StatNameKVP> Names;

        public string GetName(StatName statName)
        {
            var data = Names.FirstOrDefault(data => data.Key == statName);
            if (data == null) return "";
            return data.Value;
        }

#if UNITY_EDITOR
        [ContextMenu("Create Data")]
        private void CreateData()
        {
            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                if (Names.Any(data => data.Key == statName)) continue;
                Names.Add(new StatNameKVP { Key = statName, Value = "" });
            }
            EditorUtility.SetDirty(this);
        }
#endif
    }

    [Serializable]
    public class StatNameKVP
    {
        public StatName Key;
        public string Value;
    }
}