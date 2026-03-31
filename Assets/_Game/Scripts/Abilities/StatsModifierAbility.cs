using Gameplay;
using UnityEngine;

namespace Abilities
{
    public class StatsModifierAbility
    {
        private Stats _stats;

        public StatsModifierAbility(Stats stats)
        {
            _stats = stats;
        }

        public void Apply(
            StatName statName,
            StatModifier modifier)
        {
            _stats.AddModifier(statName, modifier);
        }
    }
}