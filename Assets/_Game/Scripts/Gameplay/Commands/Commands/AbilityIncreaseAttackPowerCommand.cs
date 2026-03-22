using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseAttackPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseAttackPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Attack;
    }

    public class AbilityIncreaseAttackPowerCommandHandler :
        AbilityAddStatModifierCommandHandler<AbilityIncreaseAttackPowerCommand>
    {
        public AbilityIncreaseAttackPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}