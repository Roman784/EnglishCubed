using Configs;
using Gameplay;
using GameRoot;
using GameSession;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryModel
    {
        private IEnumerable<AbilityConfigs> _allAbilitiesConfigs;
        private List<AcquiredAbilityData> _acquiredAbilities = new();

        public Stats HeroStats { get; private set; }

        public GameSessionProvider SessionProvider => G.GameSessionProvider;

        public AbilityInventoryModel(
            IEnumerable<AbilityConfigs> allAbilitiesConfigs,
            Stats heroStats)
        {
            _allAbilitiesConfigs = allAbilitiesConfigs;
            HeroStats = heroStats;
        }

        public IEnumerable<AcquiredAbilityData> GetAcquiredAbilities()
        {
            return _acquiredAbilities;
        }

        public void ClearAcquiredAbilities()
        {
            _acquiredAbilities.Clear();
        }

        public void AddAbility(AbilityName abilityName)
        {
            var sameAbility = _acquiredAbilities.FirstOrDefault(a => a.Configs.Name == abilityName);
            if (sameAbility != null)
            {
                sameAbility.StacksCount++;
            }
            else
            {
                var abilityConfigs = _allAbilitiesConfigs.FirstOrDefault(a => a.Name == abilityName);
                _acquiredAbilities.Add(new AcquiredAbilityData()
                {
                    Configs = abilityConfigs,
                    StacksCount = 1
                });
            }
        }

        public AbilityConfigs GetAbilityConfigs(AbilityName abilityName)
        {
            return G.AbilityProvider.GetAbilityConfigs(abilityName);
        }

        public AbilityLevelData GetCurrentLevelData(AbilityName abilityName)
        {
            var ability = _acquiredAbilities.FirstOrDefault(a => a.Configs.Name == abilityName);
            if (ability == null) return null;

            var level = Mathf.Clamp(ability.StacksCount, 0, ability.Configs.MaxStacksCount - 1);
            return ability.Configs.Levels[level];
        }

        public int GetStacksCount(AbilityName abilityName)
        {
            var ability = _acquiredAbilities.FirstOrDefault(a => a.Configs.Name == abilityName);
            if (ability == null) return 0;
            return ability.StacksCount;
        }

        public int GetMaxStacksCount(AbilityName abilityName)
        {
            var ability = _acquiredAbilities.FirstOrDefault(a => a.Configs.Name == abilityName);
            if (ability == null) return 0;
            return ability.Configs.MaxStacksCount;
        }
    }
}