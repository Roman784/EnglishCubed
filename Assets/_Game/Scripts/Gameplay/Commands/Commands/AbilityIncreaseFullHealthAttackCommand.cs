using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFullHealthAttackCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseFullHealthAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FullHealthAttack;
    }

    public class AbilityIncreaseFullHealthAttackCommandHandler :
        AbilityAddModifierCommandHandler<AbilityIncreaseFullHealthAttackCommand>
    {
        public AbilityIncreaseFullHealthAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}