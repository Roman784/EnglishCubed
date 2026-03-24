using Configs;
using GrammarValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PointMultipliersResolver
    {
        private Stats _stats;
        private PointMultiplierNamesConfigs _namesConfigs;

        private List<StatName> _bannedStatNames = new();

        public PointMultipliersResolver(Stats stats, PointMultiplierNamesConfigs namesConfigs)
        {
            _stats = stats;
            _namesConfigs = namesConfigs;

            InitBannedStatNames();
        }

        private void InitBannedStatNames()
        {
            _bannedStatNames.Add(StatName.Health);
            _bannedStatNames.Add(StatName.Armor);
            _bannedStatNames.Add(StatName.Experience);
            _bannedStatNames.Add(StatName.ExperiencePower); // <-
            _bannedStatNames.Add(StatName.Dodge); // <-
            _bannedStatNames.Add(StatName.Vampirism); // <-
            _bannedStatNames.Add(StatName.VampirismPower);
            _bannedStatNames.Add(StatName.CriticalAttackPower);
            _bannedStatNames.Add(StatName.RageDodge); // <-
            _bannedStatNames.Add(StatName.HandCapacity);
            _bannedStatNames.Add(StatName.FiveWordsPower);
            _bannedStatNames.Add(StatName.DrawsCount);
            _bannedStatNames.Add(StatName.DiscardsCount);
        }

        public IEnumerable<PointsMultiplierData> GetMultipliers(ValidationResult validationResult)
        {
            var multipliers = new List<PointsMultiplierData>();

            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                if (_bannedStatNames.Contains(statName)) continue;

                PointsMultiplierData multiplier = null;

                if (statName == StatName.DeclarativeSentencePower && validationResult.IsDeclarative || 
                    statName == StatName.InterrogativeSentencePower && validationResult.IsInterrogative ||
                    statName == StatName.ExclamatorySentencePower && validationResult.IsExclamatory ||
                    statName == StatName.PronounsPower && validationResult.HasPronouns ||
                    statName == StatName.PronounsPower && validationResult.HasAdjectives ||
                    statName == StatName.PronounsPower && validationResult.HasLinkinVerbs ||
                    statName == StatName.ThreeWordsPower && validationResult.WordsCount == 3 ||
                    statName == StatName.FourWordsPower && validationResult.WordsCount == 4 ||
                    statName == StatName.FiveWordsPower && validationResult.WordsCount == 5 ||
                    statName == StatName.Attack ||
                    statName == StatName.FullHealthAttack && _stats.Health.IsMax)
                {
                    multiplier = CalculateMultiplier(statName);
                }

                else if (statName == StatName.CriticalAttack)
                {
                    multiplier = CalculateMultiplierWithChance(statName, StatName.CriticalAttackPower);
                }

                else if (statName == StatName.RageAttack)
                {
                    multiplier = CalculateMultiplierAndMultiplyByRage(statName, _stats.Health.EmptyHeartsCount);
                }

                if (multiplier != null) 
                    multipliers.Add(multiplier);
            }

            return multipliers;
        }

        public PointsMultiplierData CalculateMultiplier(StatName statName, bool asPercentage = true)
        {
            var statValue = _stats.GetStatValue(statName);
            if (statValue == 0) return null;

            if (asPercentage)
                statValue /= 100f;

            return new PointsMultiplierData(statValue, _namesConfigs.GetName(statName));
        }

        public PointsMultiplierData CalculateMultiplierWithChance(
            StatName chanceStatName, StatName multiplierStatName, bool asPercentage = true)
        {
            var chance = _stats.GetStatValue(chanceStatName);
            var r = UnityEngine.Random.Range(0, 100);
            if (r <= chance)
                return CalculateMultiplier(multiplierStatName, asPercentage);
            return null;
        }

        public PointsMultiplierData CalculateMultiplierAndMultiplyByRage(StatName statName, int rage, bool asPercentage = true)
        {
            var statValue = _stats.GetStatValue(statName);
            if (statValue == 0) return null;

            statValue *= rage;

            if (asPercentage)
                statValue = statValue / 100f + 1f;

            return new PointsMultiplierData(statValue, _namesConfigs.GetName(statName));
        }
    }
}