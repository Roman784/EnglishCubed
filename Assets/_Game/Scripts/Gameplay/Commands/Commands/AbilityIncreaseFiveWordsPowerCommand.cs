using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFiveWordsPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseFiveWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FieldCapacity;
    }

    public class AbilityIncreaseFiveWordsPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseFiveWordsPowerCommand>
    {
        public AbilityIncreaseFiveWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}