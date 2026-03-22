using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDeclarativeSentencePowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseDeclarativeSentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.DeclarativeSentencePower;
    }

    public class AbilityIncreaseDeclarativeSentencePowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseDeclarativeSentencePowerCommand>
    {
        public AbilityIncreaseDeclarativeSentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}