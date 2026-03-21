using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseRageAttackCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseRageAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.RageAttack;
    }

    public class AbilityIncreaseRageAttackCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseRageAttackCommand>
    {
        public AbilityIncreaseRageAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}