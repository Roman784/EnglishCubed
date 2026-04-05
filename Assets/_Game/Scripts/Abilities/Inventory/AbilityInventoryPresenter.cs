using Gameplay;
using GameRoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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
            if (_model.SessionProvider.SessionData.Abilities == null) return;

            _model.ClearAcquiredAbilities();
            foreach (var ability in _model.SessionProvider.SessionData.Abilities)
            {
                for (int i = 0; i < ability.StacksCount; i++)
                {
                    var configs = _model.GetAbilityConfigs(ability.Name);
                    var use = configs.Application != AbilityApplication.Instant;
                    AddAbility(ability.Name, use);
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
            UpdateView();

            if (!use) return;

            var levelData = _model.GetCurrentLevelData(abilityName);
            var heroStatsModifier = new StatsModifierAbility(_model.HeroStats);
            var heroStatsMexIncreaser = new StatsMaxIncreaserAbility(_model.HeroStats);
            var heroStatsResorer = new StatsRestorerAblity(_model.HeroStats);

            switch (abilityName)
            {
                case AbilityName.HealthIncrease1:
                case AbilityName.HealthIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.Health,
                        levelData.GetValue(1));
                    break;

                case AbilityName.ArmorIncrease1:
                case AbilityName.ArmorIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.Armor,
                        levelData.GetValue(1));
                    break;

                case AbilityName.HealthRestoration1:
                    heroStatsResorer.Apply(
                        StatName.Health,
                        half: true);
                    break;
                case AbilityName.HealthRestoration2:
                    heroStatsResorer.Apply(
                        StatName.Health,
                        full: true);
                    break;

                case AbilityName.ArmorRestoration1:
                    heroStatsResorer.Apply(
                        StatName.Armor,
                        half: true);
                    break;
                case AbilityName.ArmorRestoration2:
                    heroStatsResorer.Apply(
                        StatName.Armor,
                        full: true);
                    break;

                case AbilityName.VampirismChanceIncrease:
                    heroStatsModifier.Apply(
                        StatName.Vampirism,
                        StatModifier.Flat(levelData.GetValue(1)));
                    heroStatsModifier.Apply(
                        StatName.VampirismPower,
                        StatModifier.Flat(levelData.GetValue(2)));
                    break;
                case AbilityName.VampirismPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.VampirismPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.ExperiencePowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.ExperiencePower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.InterrogativeSentencePowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.InterrogativeSentencePower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.DeclarativeSentencePowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.DeclarativeSentencePower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.ExclamatorySentencePowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.ExclamatorySentencePower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.HandCapacityIncrease1:
                case AbilityName.HandCapacityIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.HandCapacity,
                        levelData.GetValue(1));
                    break;

                case AbilityName.FieldCapacityIncrease1:
                case AbilityName.FieldCapacityIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.FieldCapacity,
                        levelData.GetValue(1));
                    break;

                case AbilityName.DrawsCountIncrease1:
                case AbilityName.DrawsCountIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.DrawsCount,
                        levelData.GetValue(1));
                    break;

                case AbilityName.DiscardsCountIncrease1:
                case AbilityName.DiscardsCountIncrease2:
                    heroStatsMexIncreaser.Apply(
                        StatName.DiscardsCount,
                        levelData.GetValue(1));
                    break;

                case AbilityName.AttackPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.Attack,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.DodgeChanceIncrease:
                    heroStatsModifier.Apply(
                        StatName.Dodge,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.ThreeWordPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.ThreeWordsPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.FourWordPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.FourWordsPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.FiveWordPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.FiveWordsPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.PronounsPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.PronounsPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.AdjectivesPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.AdjectivesPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
                case AbilityName.LinkingVerbsPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.LinkingVerbsPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.CriticalAttackChanceIncrease:
                    heroStatsModifier.Apply(
                        StatName.CriticalAttack,
                        StatModifier.Flat(levelData.GetValue(1)));
                    heroStatsModifier.Apply(
                        StatName.CriticalAttackPower,
                        StatModifier.Flat(levelData.GetValue(2)));
                    break;
                case AbilityName.CriticalAttackPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.CriticalAttackPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.RageAttackIncrease:
                    heroStatsModifier.Apply(
                        StatName.RageAttack,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.RageDodgeIncrease:
                    heroStatsModifier.Apply(
                        StatName.RageDodge,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.FullHealthAttackIncrease:
                    heroStatsModifier.Apply(
                        StatName.FullHealthAttack,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;

                case AbilityName.SpikesPowerIncrease:
                    heroStatsModifier.Apply(
                        StatName.SpikesPower,
                        StatModifier.Flat(levelData.GetValue(1)));
                    break;
            }
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