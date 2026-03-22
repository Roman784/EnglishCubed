using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseLinkingVerbsPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseLinkingVerbsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.LinkingVerbsPower;
    }

    public class AbilityIncreaseLinkingVerbsPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseLinkingVerbsPowerCommand>
    {
        public AbilityIncreaseLinkingVerbsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}