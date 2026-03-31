using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AbilitiesConfigs",
                     menuName = "Game Configs/Abilities/New Abilities Configs",
                     order = 0)]
    public class AbilitiesConfigs : ScriptableObject
    {
        public AbilityConfigs[] AllAbilities;
    }
}