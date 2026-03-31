using Configs;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityProvider
    {
        private IEnumerable<AbilityConfigs> _allAbilities;

        public AbilityProvider()
        {
            _allAbilities = G.Configs.AbilitiesConfigs.AllAbilities;
        }

        public AbilityConfigs GetAbilityConfigs(AbilityName abilityName)
        {
            return _allAbilities.FirstOrDefault(a => a.Name == abilityName);
        }

        public IEnumerable<AbilitySelectionData> GetAbilitiesForSelection(
            IEnumerable<AcquiredAbilityData> acquiredAbilities)
        {
            var random = new System.Random();
            return _allAbilities
                .Where(c =>
                {
                    if (c.DependsOn != AbilityName.None &&
                        !acquiredAbilities.Any(a => a.Configs.Name == c.DependsOn))
                        return false;

                    if (c.IsRepeatable)
                        return true;

                    var sameAbility = acquiredAbilities.FirstOrDefault(a => a.Configs.Name == c.Name);
                    if (sameAbility == null)
                        return true;
                    return sameAbility.StacksCount < c.MaxStacksCount;
                })
                .OrderBy(x => random.Next())
                .Take(3)
                .Select(configs => GetAbilitySelectionData(configs, acquiredAbilities));
        }

        public AbilitySelectionData GetAbilitySelectionData(
            AbilityConfigs configs, IEnumerable<AcquiredAbilityData> acquiredAbilities)
        {
            var sameAbility = acquiredAbilities.FirstOrDefault(a => a.Configs.Name == configs.Name);
            var level = sameAbility?.StacksCount ?? 0;

            return new AbilitySelectionData()
            {
                Configs = configs,
                Level = level
            };
        }
    }
}