using Commands;
using Configs;
using Gameplay;
using GameRoot;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var value2 = abilityLevelData.Values.Length > 1 ? abilityLevelData.Values[1] : 0f;

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

                case AbilityName.ExperiencePowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseExperiencePowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.InterrogativeSentencePowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseInterrogativeSentencePowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.DeclarativeSentencePowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseDeclarativeSentencePowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.ExclamatorySentencePowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseExclamatorySentencePowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.HandCapacityIncrease1:
                case AbilityName.HandCapacityIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseHandCapacityCommand(value1));
                    break;

                case AbilityName.FieldCapacityIncrease1:
                case AbilityName.FieldCapacityIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseFieldCapacityCommand(value1));
                    break;

                case AbilityName.DrawsCountIncrease1:
                case AbilityName.DrawsCountIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseDrawsCountCommand(value1));
                    break;

                case AbilityName.DiscardsCountIncrease1:
                case AbilityName.DiscardsCountIncrease2:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseDiscardsCountCommand(value1));
                    break;

                case AbilityName.AttackPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseAttackPowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.DodgeChanceIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseDodgeCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.ThreeWordPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseThreeWordsPowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.FourWordPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseFourWordsPowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.FiveWordPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseFiveWordsPowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.PronounsPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreasePronounsPowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.AdjectivesPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseAdjectivesPowerCommand(
                            StatModifier.Flat(value1)));
                    break;
                case AbilityName.LinkingVerbsPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseLinkingVerbsPowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.CriticalAttackChanceIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseCriticalAttackCommand(
                            StatModifier.Flat(value1), value2));
                    break;
                case AbilityName.CriticalAttackPowerIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseCriticalAttackPowerCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.RageAttackIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseRageAttackCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.RageDodgeIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseRageDodgeCommand(
                            StatModifier.Flat(value1)));
                    break;

                case AbilityName.FullHealthAttackIncrease:
                    G.CommandProcessor.Process(
                        new AbilityIncreaseFullHealthAttackCommand(
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