using Abilities;
using Gameplay;
using System;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Configs
{
    [CreateAssetMenu(fileName = "AbilityConfigs",
                     menuName = "Game Configs/Abilities/New Ability Configs",
                     order = 1)]
    public class AbilityConfigs : ScriptableObject
    {
        public AbilityName Name;
        public AbilityName DependsOn;
        public AbilityApplication Application;
        public bool IsRepeatable;
        public Rarity Rarity;
        public Weight Weight;
        public bool ShowInInventory;

        [Space]

        public AbilityLevelData[] Levels;

        public int MaxStacksCount => Levels.Length;

#if UNITY_EDITOR
        [ContextMenu("Set Ability Name")]
        private void SetAbilityName()
        {
            var confName = name.Split('_')[0];

            foreach (AbilityName abilityName in Enum.GetValues(typeof(AbilityName)))
            {
                if (abilityName.ToString() != confName) continue;
                
                Name = abilityName;
                EditorUtility.SetDirty(this);
                return;
            }

            Debug.LogWarning($"Failed to find ability name for {confName}!");
        }
    }
#endif

    [Serializable]
    public class AbilityLevelData
    {
        public Sprite Icon;
        public string Title;
        [TextArea(2, 3)]public string Description;
        [TextArea(2, 3)]public string Details;

        public float[] Values;
    }
}