using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseVampirismPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseVampirismPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.VampirismPower;
    }

    public class AbilityIncreaseVampirismPowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseVampirismPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}