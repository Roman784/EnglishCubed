using Abilities;
using System;
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
        public bool IsRepeatable;
        public Rarity Rarity;
        public Weight Weight;

        [Space]

        public AbilityLevelData[] Levels;

        public int MaxStacksCount => Levels.Length;
    }

    [Serializable]
    public class AbilityLevelData
    {
        public Sprite Icon;
        public string Title;
        public string Description;
    }
}