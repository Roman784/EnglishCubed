using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDodgeCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseDodgeCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Dodge;
    }

    public class AbilityIncreaseDodgeCommandhandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseDodgeCommand>
    {
        public AbilityIncreaseDodgeCommandhandler(Stats stats) : base(stats)
        {
        }
    }
}