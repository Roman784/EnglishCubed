using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreasePronounsPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreasePronounsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.PronounsPower;
    }

    public class AbilityIncreasePronounsPowerCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreasePronounsPowerCommand>
    {
        public AbilityIncreasePronounsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}