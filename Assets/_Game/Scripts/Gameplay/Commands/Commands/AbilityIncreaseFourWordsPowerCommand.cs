using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFourWordsPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseFourWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.FourWordsPower;
    }

    public class AbilityIncreaseFourWordsPowerCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseFourWordsPowerCommand>
    {
        public AbilityIncreaseFourWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}