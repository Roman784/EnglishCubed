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
        public AbilityLevel[] Levels;
    }

    [Serializable]
    public class AbilityLevel
    {
        public Sprite Icon;
        public string Title;
        public string Description;
    }
}