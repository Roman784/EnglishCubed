using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseThreeWordsPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseThreeWordsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.ThreeWordsPower;
    }

    public class AbilityIncreaseThreeWordsPowerCommandHandler :
        AbilityAddModifierCommandHandler<AbilityIncreaseThreeWordsPowerCommand>
    {
        public AbilityIncreaseThreeWordsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}