using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDodgeCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseDodgeCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Dodge;
    }

    public class AbilityIncreaseDodgeCommandhandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseDodgeCommandhandler(Stats stats) : base(stats)
        {
        }
    }
}