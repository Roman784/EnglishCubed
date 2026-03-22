using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseCriticalAttackCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseCriticalAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.CriticalAttack;
    }

    public class AbilityIncreaseCriticalAttackCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseCriticalAttackCommand>
    {
        public AbilityIncreaseCriticalAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}