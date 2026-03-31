using Gameplay;
using UnityEngine;

namespace Abilities
{
    public class StatsMaxIncreaserAbility
    {
        private Stats _stats;

        public StatsMaxIncreaserAbility(Stats stats)
        {
            _stats = stats;
        }

        public void Apply(
            StatName statName,
            float value)
        {
            var stat = _stats.GetStatOrCreateNew(statName);
            stat.SetMax(stat.Max + value);
        }
    }
}