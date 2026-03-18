using Configs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryPresenter
    {
        private readonly AbilityInventoryModel _model;
        private readonly AbilityInventoryView _view;

        public AbilityInventoryPresenter(
            AbilityInventoryView view,
            AbilityInventoryModel model)
        {
            _view = view;
            _model = model;
        }

        public IEnumerable<AbilityConfigs> GetAbilitiesForSelection()
        {
            var random = new System.Random();
            return _model.AllConfigs
                .Where(c =>
                {
                    if (c.DependsOn != AbilityName.None &&
                        _model.AcquiredAbilitiesMap.Where(a => a.Key == c.DependsOn).Count() == 0)
                        return false;

                    if (!_model.AcquiredAbilitiesMap.ContainsKey(c.Name))
                        return true;

                    if (c.IsRepeatable) 
                        return true;

                    return _model.AcquiredAbilitiesMap[c.Name].StacksCount < c.MaxStacksCount;
                })
                .OrderBy(x => random.Next())
                .Take(3);
        }

        public void AcquireAbility(AbilityName abilityName)
        {
            _model.AcquireAbility(abilityName);

            var abilityLevelData = _model.GetCurrentLevelData(abilityName);
            // TODO: Apply ability.

            UpdateView();
        }

        private void UpdateView()
        {
            var iconData = new List<AbilityIconData>();

            foreach (var ability in _model.AcquiredAbilitiesMap.Values)
            {
                if (ability.Configs.IsRepeatable) continue;

                var levelData = _model.GetCurrentLevelData(ability.Configs.Name);
                var stacksCount = _model.GetStacksCount(ability.Configs.Name);
                var isMaxStacks = _model.IsMaxStacks(ability.Configs.Name);

                iconData.Add(new AbilityIconData()
                {
                    Icon = levelData?.Icon,
                    StacksCount = stacksCount,
                    IsMaxStacks = isMaxStacks,
                });
            }

            _view.DisplayAbilities(iconData);
        }
    }
}