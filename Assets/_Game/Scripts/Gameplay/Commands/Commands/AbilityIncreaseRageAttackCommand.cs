using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseRageAttackCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseRageAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.RageAttack;
    }

    public class AbilityIncreaseRageAttackCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseRageAttackCommand>
    {
        public AbilityIncreaseRageAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}