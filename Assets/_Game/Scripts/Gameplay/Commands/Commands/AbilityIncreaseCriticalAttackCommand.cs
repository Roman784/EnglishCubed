using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseCriticalAttackCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseCriticalAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.CriticalAttack;
    }

    public class AbilityIncreaseCriticalAttackCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseCriticalAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}