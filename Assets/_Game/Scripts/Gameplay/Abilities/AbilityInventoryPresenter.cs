using Commands;
using Configs;
using Gameplay;
using GameRoot;
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

        public IEnumerable<(AbilityConfigs, AbilityLevelData)> GetAbilitiesForSelection()
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
                .Take(3)
                .Select(a => (a, _model.GetCurrentLevelDataOrFirst(a.Name)));
        }

        public void AcquireAbility(AbilityName abilityName)
        {
            _model.AcquireAbility(abilityName);

            var abilityLevelData = _model.GetCurrentLevelDataOrFirst(abilityName);
            var value1 = abilityLevelData.Values.Length > 0 ? abilityLevelData.Values[0] : 0f;

            switch (abilityName)
            {
                case AbilityName.HealthIncrease1: 
                case AbilityName.HealthIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseHealthCommand(Mathf.FloorToInt(value1)));
                    break;

                case AbilityName.ArmorIncrease1:
                case AbilityName.ArmorIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseArmorCommand(Mathf.FloorToInt(value1)));
                    break;

                case AbilityName.HealthRestoration1:
                    G.CommandProcessor.Process(
                        new AbilityRestoreHealthCommand(half: true));
                    break;
                case AbilityName.HealthRestoration2:
                    G.CommandProcessor.Process(
                        new AbilityRestoreHealthCommand(full: true));
                    break;

                case AbilityName.ArmorRestoration1:
                    G.CommandProcessor.Process(
                        new AbilityRestoreArmorCommand(half: true));
                    break;
                case AbilityName.ArmorRestoration2:
                    G.CommandProcessor.Process(
                        new AbilityRestoreArmorCommand(full: true));
                    break;

                case AbilityName.VampirismChanceIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseVampirismCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.VampirismPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseVampirismPowerCommand(
                            StatModifier.Flat(value1)));
                    break;
            }

            UpdateView();
        }

        private void UpdateView()
        {
            var iconData = new List<AbilityIconData>();

            foreach (var ability in _model.AcquiredAbilitiesMap.Values)
            {
                if (ability.Configs.IsRepeatable) continue;

                var levelData = _model.GetCurrentLevelDataOrFirst(ability.Configs.Name);
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