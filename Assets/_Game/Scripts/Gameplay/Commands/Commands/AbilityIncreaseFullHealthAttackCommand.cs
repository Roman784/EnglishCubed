using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFullHealthAttackCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseFullHealthAttackCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FullHealthAttack;
    }

    public class AbilityIncreaseFullHealthAttackCommandHandler :
        AbilityAddStatModifierCommandHandler<AbilityIncreaseFullHealthAttackCommand>
    {
        public AbilityIncreaseFullHealthAttackCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}