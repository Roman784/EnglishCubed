
using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDrawsCountCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseDrawsCountCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.DrawsCount;
    }

    public class AbilityIncreaseDrawsCountCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseDrawsCountCommand>
    {
        public AbilityIncreaseDrawsCountCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}