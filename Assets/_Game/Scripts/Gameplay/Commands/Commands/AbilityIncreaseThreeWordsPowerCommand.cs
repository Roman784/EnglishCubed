using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseThreeWordsPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseThreeWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ThreeWordsPower;
    }

    public class AbilityIncreaseThreeWordsPowerCommandHandler :
        AbilityAddStatModifierCommandHandler<AbilityIncreaseThreeWordsPowerCommand>
    {
        public AbilityIncreaseThreeWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}