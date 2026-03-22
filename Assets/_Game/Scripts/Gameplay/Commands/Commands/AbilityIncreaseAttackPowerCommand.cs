using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseAttackPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseAttackPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Attack;
    }

    public class AbilityIncreaseAttackPowerCommandHandler :
        AbilityAddModifierCommandHandler<AbilityIncreaseAttackPowerCommand>
    {
        public AbilityIncreaseAttackPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}