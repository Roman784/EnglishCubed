using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseExclamatorySentencePowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseExclamatorySentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ExclamatorySentencePower;
    }

    public class AbilityIncreaseExclamatorySentencePowerCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseExclamatorySentencePowerCommand>
    {
        public AbilityIncreaseExclamatorySentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}