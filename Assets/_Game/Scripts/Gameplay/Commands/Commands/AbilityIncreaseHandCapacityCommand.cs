using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseHandCapacityCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseHandCapacityCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.HandCapacity;
    }

    public class AbilityIncreaseHandCapacityCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseHandCapacityCommand>
    {
        public AbilityIncreaseHandCapacityCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}