using Configs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryModel
    {
        private Dictionary<AbilityName, AcquiredAbilityData> _acquiredAbilitiesMap = new();

        public IEnumerable<AbilityConfigs> AllConfigs { get; private set; }
        public IReadOnlyDictionary<AbilityName, AcquiredAbilityData> AcquiredAbilitiesMap => _acquiredAbilitiesMap;

        public AbilityInventoryModel(IEnumerable<AbilityConfigs> allConfigs)
        {
            AllConfigs = allConfigs;
        }

        public void AcquireAbility(AbilityName abilityName)
        {
            var configs = GetAbilityConfigs(abilityName);
            if (configs == null) return;

            if (!_acquiredAbilitiesMap.ContainsKey(abilityName))
                _acquiredAbilitiesMap[abilityName] = new AcquiredAbilityData() { Configs = configs };

            _acquiredAbilitiesMap[abilityName].StacksCount += 1;
        }

        public int GetStacksCount(AbilityName abilityName)
        {
            if (_acquiredAbilitiesMap.TryGetValue(abilityName, out var data))
                return Mathf.Clamp(data.StacksCount, 0, data.Configs.MaxStacksCount);
            return 0;
        }

        public bool IsMaxStacks(AbilityName abilityName)
        {
            var stacks = GetStacksCount(abilityName);
            var configs = GetAbilityConfigs(abilityName);
            return stacks >= configs?.MaxStacksCount;
        }

        public AbilityLevelData GetCurrentLevelDataOrFirst(AbilityName abilityName)
        {
            var stacks = GetStacksCount(abilityName);
            var configs = GetAbilityConfigs(abilityName);

            if (stacks >= 0 && stacks <= configs?.MaxStacksCount - 1)
                return configs?.Levels[stacks];
            return configs?.Levels[0];
        }

        private AbilityConfigs GetAbilityConfigs(AbilityName abilityName)
        {
            return AllConfigs.FirstOrDefault(c => c.Name == abilityName);
        }
    }
}