using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseVampirismPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseVampirismPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.VampirismPower;
    }

    public class AbilityIncreaseVampirismPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseVampirismPowerCommand> 
    {
        public AbilityIncreaseVampirismPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}