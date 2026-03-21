using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFiveWordsPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseFiveWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FieldCapacity;
    }

    public class AbilityIncreaseFiveWordsPowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseFiveWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}