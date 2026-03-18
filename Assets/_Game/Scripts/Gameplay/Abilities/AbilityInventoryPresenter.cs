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

        public IEnumerable<AbilityConfigs> GetAbilitiesForSelection() => _model.GetUnacquiredAbilities(3);

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

            foreach (var ability in _model.AcquiredAbilities.Values)
            {
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