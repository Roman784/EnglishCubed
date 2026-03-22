using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFieldCapacityCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseFieldCapacityCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FieldCapacity;
    }

    public class AbilityIncreaseFieldCapacityCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseFieldCapacityCommand>
    {
        public AbilityIncreaseFieldCapacityCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}