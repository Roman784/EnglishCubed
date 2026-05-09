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
    }
}
