using Configs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryModel
    {
        private Dictionary<AbilityName, AcquiredAbilityData> _abilitiesMap = new();

        public IEnumerable<AbilityConfigs> AllConfigs { get; private set; }
        public IReadOnlyDictionary<AbilityName, AcquiredAbilityData> AcquiredAbilitiesMap => _abilitiesMap;

        public AbilityInventoryModel(IEnumerable<AbilityConfigs> allConfigs)
        {
            AllConfigs = allConfigs;
        }

        public void AddAbility(AbilityName abilityName)
        {
            var configs = GetAbilityConfigs(abilityName);
            if (configs == null) return;

            if (!_abilitiesMap.ContainsKey(abilityName))
                _abilitiesMap[abilityName] = new AcquiredAbilityData() { Configs = configs };

            _abilitiesMap[abilityName].StacksCount += 1;
        }

        public int GetStacksCount(AbilityName abilityName)
        {
            if (_abilitiesMap.TryGetValue(abilityName, out var data))
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

            if (stacks > 0 && stacks <= configs?.MaxStacksCount)
                return configs?.Levels[stacks - 1];
            return configs?.Levels[0];
        }

        public AbilityLevelData GetLevelDataForNextStack(AbilityName abilityName)
        {
            var stacks = GetStacksCount(abilityName);
            var configs = GetAbilityConfigs(abilityName);

            if (stacks >= 0 && stacks < configs?.MaxStacksCount)
                return configs?.Levels[stacks];
            return null;
        }

        public AbilityConfigs GetAbilityConfigs(AbilityName abilityName)
        {
            return AllConfigs.FirstOrDefault(c => c.Name == abilityName);
        }

        public (AbilityName, int)[] GetAcquiredAbilities()
        {
            return AcquiredAbilitiesMap
                .Select(kv => (kv.Key, kv.Value.StacksCount))
                .ToArray();
        }
    }
}