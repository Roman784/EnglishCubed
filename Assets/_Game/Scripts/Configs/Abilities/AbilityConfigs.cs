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
        public int Price;

        [Space]

        public AbilityLevelData[] Levels;

        public Sprite Icon => Levels.Length > 0 ? Levels[0].Icon : null;
        public string Title => Levels.Length > 0 ? Levels[0].Title : string.Empty;
        public string Description => Levels.Length > 0 ? Levels[0].Description : string.Empty;

        public int MaxStacksCount => Levels.Length;

        public int TrueWeight => Rarity.Number() * Weight.Number();

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
#endif
    }

    [Serializable]
    public class AbilityLevelData
    {
        public Sprite Icon;
        public string Title;
        [TextArea(2, 3)]public string Description;
        [TextArea(2, 3)]public string Details;

        public float[] Values;

        public float GetValue(int level)
        {
            var index = level - 1;
            if (Values == null) return 0f;
            if (Values.Length == 0) return 0f;
            if (index > Values.Length - 1) return 0f;
            if (index < 0) return 0f;
            return Values[index];
        }
    }
}