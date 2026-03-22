using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseExperiencePowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseExperiencePowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ExperiencePower;
    }

    public class AbilityIncreaseExperiencePowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseExperiencePowerCommand>
    {
        public AbilityIncreaseExperiencePowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}