using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDeclarativeSentencePowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseDeclarativeSentencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.DeclarativeSentencePower;
    }

    public class AbilityIncreaseDeclarativeSentencePowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseDeclarativeSentencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}