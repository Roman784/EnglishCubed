using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseInterrogativeSentencePowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseInterrogativeSentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.InterrogativeSentencePower;
    }

    public class AbilityIncreaseInterrogativeSentencePowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseInterrogativeSentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}