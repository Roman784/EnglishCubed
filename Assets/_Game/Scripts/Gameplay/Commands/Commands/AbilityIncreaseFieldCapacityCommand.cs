using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFieldCapacityCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseFieldCapacityCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FieldCapacity;
    }

    public class AbilityIncreaseFieldCapacityCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseFieldCapacityCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}