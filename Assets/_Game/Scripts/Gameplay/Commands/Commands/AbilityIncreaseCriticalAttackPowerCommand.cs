using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseCriticalAttackPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseCriticalAttackPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.CriticalAttackPower;
    }

    public class AbilityIncreaseCriticalAttackPowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseCriticalAttackPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}