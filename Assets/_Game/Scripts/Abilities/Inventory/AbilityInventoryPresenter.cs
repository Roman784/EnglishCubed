using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryPresenter    
    {
        private AbilityInventoryView _view;
        private AbilityInventoryModel _model;

        public AbilityInventoryPresenter(
            AbilityInventoryView view, 
            AbilityInventoryModel model)
        {
            _view = view;
            _model = model;
        }

        public void Load()
        {
            _model.ClearAcquiredAbilities();
            foreach (var ability in _model.SessionProvider.SessionData.Abilities)
            {
                for (int i = 0; i < ability.StacksCount; i++)
                {
                    var configs = _model.GetAbilityConfigs(ability.Name);
                    var use = configs.Application != AbilityApplication.Instant;
                    AddAbility(ability.Name);
                }
            }
        }

        public void Save()
        {
            var abilitiesForSave = new List<AbilitySaveData>();
            foreach (var ability in _model.GetAcquiredAbilities())
            {
                abilitiesForSave.Add(new AbilitySaveData()
                {
                    Name = ability.Configs.Name,
                    StacksCount = ability.StacksCount
                });
            }
            _model.SessionProvider.SetAbilities(abilitiesForSave);
        }

        public void AddAbility(AbilityName abilityName, bool use = true)
        {
            _model.AddAbility(abilityName);

            // USE HERE.

            UpdateView();
        }

        public IEnumerable<AcquiredAbilityData> GetAcquiredAbilities()
        {
            return _model.GetAcquiredAbilities();
        }

        private void UpdateView()
        {
            var iconsData = new List<AbilityIconData>();

            foreach (var ability in _model.GetAcquiredAbilities())
            {
                if (!ability.Configs.ShowInInventory) continue;

                var levelData = _model.GetCurrentLevelData(ability.Configs.Name);
                var stacksCount = _model.GetStacksCount(ability.Configs.Name);
                var isMaxStacks = _model.GetMaxStacksCount(ability.Configs.Name) == stacksCount;

                iconsData.Add(new AbilityIconData()
                {
                    Icon = levelData?.Icon,
                    StacksCount = stacksCount,
                    IsMaxStacks = isMaxStacks,
                });
            }

            _view.UpdateIcons(iconsData);
        }
    }
}