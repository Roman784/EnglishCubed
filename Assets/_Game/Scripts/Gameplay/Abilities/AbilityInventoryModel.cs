using Configs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryModel    
    {
        public IEnumerable<AbilityConfigs> AllConfigs { get; private set; }

        private Dictionary<AbilityName, List<AbilityConfigs>> _abilitiesMap = new();

        public AbilityInventoryModel(
            IEnumerable<AbilityConfigs> allConfigs)
        {
            AllConfigs = allConfigs;
        }

        public AbilityLevelData AddAbility(AbilityName abilityName)
        {
            var configs = GetAbilityConfigs(abilityName);
            if (configs == null) return null;

            if (!_abilitiesMap.ContainsKey(abilityName))
                _abilitiesMap[abilityName] = new List<AbilityConfigs>();
 
            _abilitiesMap[abilityName].Add(configs);

            return GetAbilityLevelData(configs);
        }

        public IEnumerable<AbilityIconData> GetAbilityIconsData()
        {
            var iconsData = new List<AbilityIconData>();
            foreach (var configsList in _abilitiesMap.Values)
            {
                var configs = configsList[0];
                var levelData = GetAbilityLevelData(configs);
                var stacksCount = GetStacksCount(configs);
                var isMaxStacks = IsMaxStacksCount(stacksCount, configs);

                iconsData.Add(new AbilityIconData()
                {
                    Icon = levelData.Icon,
                    StacksCount = stacksCount,
                    IsMaxStacks = isMaxStacks,
                });
            }
            return iconsData;
        }

        private AbilityConfigs GetAbilityConfigs(AbilityName abilityName)
        {
            return AllConfigs.FirstOrDefault(c => c.Name == abilityName);
        }

        private AbilityLevelData GetAbilityLevelData(AbilityConfigs configs)
        {
            var lastStackIdx = GetStacksCount(configs) - 1;

            if (lastStackIdx >= 0 && lastStackIdx < configs.Levels.Length) 
                return configs.Levels[lastStackIdx];
            return null;
        }

        private int GetStacksCount(AbilityConfigs configs)
        {
            if (_abilitiesMap.TryGetValue(configs.Name, out var stacks))
                return Mathf.Clamp(stacks.Count, 0, configs.MaxStacksCount);
            return -1;
        }

        private bool IsMaxStacksCount(int stackNumber, AbilityConfigs configs)
        {
            return stackNumber == configs.MaxStacksCount;
        }
    }
}