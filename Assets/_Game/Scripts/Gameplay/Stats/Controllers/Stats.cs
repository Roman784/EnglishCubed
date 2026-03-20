using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
            SetDefaultStats();
        }

        public void SetStat(Stat stat)
        {
            _statsMap[stat.Name] = stat;
        }

        public Stat GetStat(StatName name)
        {
            if (_statsMap.TryGetValue(name, out var stat)) return stat;
            return null;
        }

        public float GetStatValue(StatName name)
        {
            var res = _statsMap.TryGetValue(name, out var stat);
            if (!res) return 0f;

            return ApplyModifiers(stat);
        }

        public void AddModifier(StatName statName, StatModifier modifier)
        {
            if (!_modifiersMap.ContainsKey(statName))
                _modifiersMap[statName] = new List<StatModifier>();
            _modifiersMap[statName].Add(modifier);
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

        private void SetStats(Stat[] stats)
        {
            if (stats == null || stats.Length == 0) return;

            foreach (var stat in stats)
            {
                SetStat(stat);
            }
        }

        private void SetDefaultStats()
        {
            foreach (StatName name in Enum.GetValues(typeof(StatName)))
            {
                if (_statsMap.ContainsKey(name)) continue;
                _statsMap[name] = new Stat(name, 0, 0);
            }
        }
    }
}