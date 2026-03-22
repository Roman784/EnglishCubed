using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreasePronounsPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreasePronounsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.PronounsPower;
    }

    public class AbilityIncreasePronounsPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreasePronounsPowerCommand>
    {
        public AbilityIncreasePronounsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}