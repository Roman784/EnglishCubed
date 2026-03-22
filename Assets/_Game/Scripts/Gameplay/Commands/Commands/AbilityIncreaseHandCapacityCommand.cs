using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseHandCapacityCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseHandCapacityCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.HandCapacity;
    }

    public class AbilityIncreaseHandCapacityCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseHandCapacityCommand>
    {
        public AbilityIncreaseHandCapacityCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}