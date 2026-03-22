using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseInterrogativeSentencePowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseInterrogativeSentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.InterrogativeSentencePower;
    }

    public class AbilityIncreaseInterrogativeSentencePowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseInterrogativeSentencePowerCommand>
    {
        public AbilityIncreaseInterrogativeSentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}