using Configs;
using GameProducer;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityProvider
    {
        private readonly IEnumerable<AbilityConfigs> _allAbilities;

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
            return G.GameProducer.Ability.GetThree(acquiredAbilities);
        }

        public AbilitySelectionData GetAbilitySelectionData(
            AbilityConfigs configs,
            IEnumerable<AcquiredAbilityData> acquiredAbilities)
        {
            var sameAbility = acquiredAbilities
                .FirstOrDefault(a => a.Configs.Name == configs.Name);

            return new AbilitySelectionData()
            {
                Configs = configs,
                Level = sameAbility?.StacksCount ?? 0
            };
        }
    }
}
