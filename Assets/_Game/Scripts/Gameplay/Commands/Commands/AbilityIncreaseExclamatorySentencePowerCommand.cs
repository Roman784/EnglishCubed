using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseExclamatorySentencePowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseExclamatorySentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ExclamatorySentencePower;
    }

    public class AbilityIncreaseExclamatorySentencePowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseExclamatorySentencePowerCommand>
    {
        public AbilityIncreaseExclamatorySentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}