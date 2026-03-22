
using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDrawsCountCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseDrawsCountCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.DrawsCount;
    }

    public class AbilityIncreaseDrawsCountCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseDrawsCountCommand>
    {
        public AbilityIncreaseDrawsCountCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}