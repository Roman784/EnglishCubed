using Abilities;
using Configs;
using GameRoot;
using GameState;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace AbilityMenu
{
    public class AbilityMenuModel
    {
        public IEnumerable<AbilityConfigs> AllAbilitiesConfigs { get; private set; }
        public IEnumerable<AbilityName> UnlockedAbilities { get; private set; }
        public Dictionary<AbilityName, AbilitySelectionButton> AbilitySelectionButtonsMap { get; private set; }

        public AbilityConfigs SelectedAbility { get; private set; }

        public MetaProgressionRepository Repository => G.Repository.MetaProgression;

        public AbilityMenuModel(
            IEnumerable<AbilityConfigs> allAbilitiesConfigs,
            IEnumerable<AbilityName> unlockedAbilities)
        {
            AllAbilitiesConfigs = allAbilitiesConfigs;
            UnlockedAbilities = unlockedAbilities;
        }

        public void SetAbilitySelectionButtonsMap(
            Dictionary<AbilityName, AbilitySelectionButton> abilitySelectionButtonsMap)
        {
            AbilitySelectionButtonsMap = abilitySelectionButtonsMap;
        }

        public bool IsAbilityUnlocked(AbilityName abilityName)
        {
            return UnlockedAbilities.Contains(abilityName);
        }

        public void SetSelectedAbility(AbilityConfigs abilityConfigs)
        {
            SelectedAbility = abilityConfigs;
        }

        public void UnlockSelectedAbility()
        {
            if (SelectedAbility == null || IsAbilityUnlocked(SelectedAbility.Name)) return;
            UnlockedAbilities = UnlockedAbilities.Append(SelectedAbility.Name);
        }
    }
}