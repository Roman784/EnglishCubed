using Abilities;
using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AbilityConfigs",
                     menuName = "Game Configs/Abilities/New Ability Configs",
                     order = 1)]
    public class AbilityConfigs : ScriptableObject
    {
        public AbilityName Name;
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