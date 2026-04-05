using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gameplay
{
    public class Stats
    {
        private Dictionary<StatName, Stat> _statsMap = new();
        private Dictionary<StatName, List<StatModifier>> _modifiersMap = new();

        public Health Health => (Health)_statsMap[StatName.Health];
        public Armor Armor => (Armor)_statsMap[StatName.Armor];
        public Experience Experience => (Experience)_statsMap[StatName.Experience];

        public Stats(params Stat[] stats)
        {
            SetStats(stats);
        }

        public Stats(
            IEnumerable<StatData> initialStats, IEnumerable<StatData> loadedStats)
        {
            foreach (var initialStat in initialStats)
            {
                var statName = initialStat.Name;
                var loadedStat = loadedStats?.FirstOrDefault(s => s.Name == initialStat.Name);
                if (loadedStat != null)
                    _statsMap[statName] = CreateStat(loadedStat);
                else
                    _statsMap[statName] = CreateStat(initialStat);
            }
        }

        public void SetStat(Stat stat)
        {
            _statsMap[stat.Name] = stat;
        }

        public IEnumerable<StatData> GetStatsData()
        {
            return _statsMap.Values.Select(s => new StatData()
            {
                Name = s.Name,
                Value = s.CurrentValue,
                Max = s.Max
            });
        }

        public Stat GetStatOrCreateNew(StatName name)
        {
            if (_statsMap.TryGetValue(name, out var stat)) return stat;
            var createdStat = new Stat(name, 0, 0);
            _statsMap[createdStat.Name] = createdStat;
            return createdStat;
        }

        public float GetStatValue(StatName name)
        {
            if (!_statsMap.TryGetValue(name, out var stat)) return 0f;
            return ApplyModifiers(stat);
        }

        public void AddModifier(StatName statName, StatModifier modifier)
        {
            GetStatOrCreateNew(statName); // If it doesnt exist.
            if (!_modifiersMap.ContainsKey(statName))
                _modifiersMap[statName] = new List<StatModifier>();
            _modifiersMap[statName].Add(modifier);
        }

        public bool IsExistAndNotZero(StatName name)
        {
            return _statsMap.ContainsKey(name) && GetStatValue(name) > 0;
        }

        public bool IsChanceSuccess(StatName statName)
        {
            var chance = GetStatValue(statName);
            return chance < UnityEngine.Random.Range(0, 100);
        }

        public bool IsChanceSuccessWithRage(StatName statName, StatName rageStatName)
        {
            var chance = GetStatValue(statName) + GetStatValue(rageStatName) * Health.EmptyHeartsCount;
            return chance < UnityEngine.Random.Range(0, 100);
        }

        public int CalculateExperience(int points)
        {
            return Mathf.CeilToInt(points * (GetStatValue(StatName.ExperiencePower) / 100f + 1f));
        }

        public bool TryApplyVampirism()
        {
            if (IsChanceSuccess(StatName.Vampirism))
            {
                var healthForRestore = Mathf.RoundToInt(GetStatValue(StatName.VampirismPower));
                Health.Restore(healthForRestore);
                return true;
            }
            return false;
        }

        private void SetStats(IEnumerable<Stat> stats)
        {
            if (stats == null) return;
            foreach (var stat in stats)
            {
                if (_statsMap.ContainsKey(stat.Name)) continue;
                SetStat(stat);
            }
        }

        private float ApplyModifiers(Stat stat)
        {
            var result = stat.CurrentValue;

            if (!_modifiersMap.TryGetValue(stat.Name, out var modifiers))
                return result;

            var flatModifiers = modifiers.Where(m => m.ModifierType == ModifierType.Flat);
            var multiplierModifiers = modifiers.Where(m => m.ModifierType == ModifierType.Multiplier);
            var customModifiers = modifiers.Where(m => m.ModifierType == ModifierType.Custom);

            var flatBonus = 0f;
            foreach (var modifier in flatModifiers)
                flatBonus += modifier.Value;

            result += flatBonus;

            var multiplierBonus = 1f;
            foreach(var modifier in multiplierModifiers)
                multiplierBonus += modifier.Value;

            result *= multiplierBonus;

            foreach (var modifier in customModifiers)
                result += modifier.СustomFormula(result);

            return result;
        }

        private Stat CreateStat(StatData data)
        {
            if (data.Name == StatName.Health)
                return new Health((int)data.Value, (int)data.Max);
            else if (data.Name == StatName.Armor)
                return new Armor((int)data.Value, (int)data.Max);
            return new Stat(data.Name, data.Value, data.Max);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var stat in _statsMap.Values)
                stringBuilder.AppendLine($"{stat.Name}: {GetStatValue(stat.Name)}");
            return stringBuilder.ToString();
        }
    }
}