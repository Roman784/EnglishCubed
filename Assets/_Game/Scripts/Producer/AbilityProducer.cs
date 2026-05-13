using Abilities;
using Configs;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProducer
{
    public class AbilityProducer
    {
        private GameProducerContext _context;

        private IEnumerable<AbilityConfigs> AllAbilitiesConfigs => G.Configs.AbilitiesConfigs.AllAbilities;

        public AbilityProducer(GameProducerContext context)
        {
            _context = context;
        }

        public IEnumerable<AbilitySelectionData> GetThree(IEnumerable<AcquiredAbilityData> acquiredAbilities)
        {
            var availableAbilities = GetUnlockedAbilities()
                .Where(c => IsAvailable(c, acquiredAbilities))
                .ToList();

            var result = new List<AbilitySelectionData>();

            for (int i = 0; i < 3; i++)
            {
                if (availableAbilities.Count == 0)
                    break;

                var weightedArray = availableAbilities
                    .Select(a => (item: a, weight: a.TrueWeight))
                    .ToArray();

                var selected = WeightedRandom.Get(weightedArray);

                availableAbilities.Remove(selected);

                var sameAbility = acquiredAbilities
                    .FirstOrDefault(a => a.Configs.Name == selected.Name);

                result.Add(new AbilitySelectionData()
                {
                    Configs = selected,
                    Level = sameAbility?.StacksCount ?? 0
                });
            }

            return result;
        }

        private bool IsAvailable(
            AbilityConfigs configs,
            IEnumerable<AcquiredAbilityData> acquiredAbilities)
        {
            if (configs.DependsOn != AbilityName.None &&
                !acquiredAbilities.Any(a => a.Configs.Name == configs.DependsOn))
            {
                return false;
            }

            if (configs.IsRepeatable)
                return true;

            var sameAbility = acquiredAbilities
                .FirstOrDefault(a => a.Configs.Name == configs.Name);

            if (sameAbility == null)
                return true;

            return sameAbility.StacksCount < configs.MaxStacksCount;
        }

        private IEnumerable<AbilityConfigs> GetUnlockedAbilities()
        {
            var unlockedNames = G.Repository.MetaProgression.GetUnlockedAbilities().ToList();
            return AllAbilitiesConfigs.Where(a => unlockedNames.Contains(a.Name));
        }
    }
}