using Gameplay;
using UnityEngine;

namespace Abilities
{
    public class StatsRestorerAblity
    {
        private Stats _stats;

        public StatsRestorerAblity(Stats stats)
        {
            _stats = stats;
        }

        public void Apply(
            StatName statName,
            float value = 0,
            bool half = false, 
            bool full = false)
        {
            var stat = _stats.GetStatOrCreateNew(statName);
            if (full)
                stat.Add(Mathf.CeilToInt(stat.Max - stat.CurrentValue));
            else if (half)
                stat.Add(Mathf.CeilToInt((stat.Max - stat.CurrentValue) / 2f));
            else
                stat.Add(value);
        }
    }
}