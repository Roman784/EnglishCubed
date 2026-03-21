using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseExperiencePowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseExperiencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ExperiencePower;
    }

    public class AbilityIncreaseExperiencePowerCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseExperiencePowerCommand>
    {
        public AbilityIncreaseExperiencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}