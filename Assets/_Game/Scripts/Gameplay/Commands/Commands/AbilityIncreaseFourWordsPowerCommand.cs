using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFourWordsPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseFourWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FourWordsPower;
    }

    public class AbilityIncreaseFourWordsPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseFourWordsPowerCommand>
    {
        public AbilityIncreaseFourWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}