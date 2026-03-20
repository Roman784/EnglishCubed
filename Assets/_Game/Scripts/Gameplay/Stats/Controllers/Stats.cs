using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Gameplay
{
    public class Stats
    {
        public Dictionary<StatName, Stat> _statsMap = new();

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

        public bool TryGetStat(StatName name, out Stat stat)
        {
            return _statsMap.TryGetValue(name, out stat);
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