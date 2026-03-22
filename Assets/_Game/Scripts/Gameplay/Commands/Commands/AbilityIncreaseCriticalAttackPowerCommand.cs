using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseCriticalAttackPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseCriticalAttackPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.CriticalAttackPower;
    }

    public class AbilityIncreaseCriticalAttackPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseCriticalAttackPowerCommand>
    {
        public AbilityIncreaseCriticalAttackPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}