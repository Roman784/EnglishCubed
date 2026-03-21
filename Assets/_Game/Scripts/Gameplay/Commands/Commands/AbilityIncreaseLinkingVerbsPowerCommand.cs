using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseLinkingVerbsPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseLinkingVerbsPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.LinkingVerbsPower;
    }

    public class AbilityIncreaseLinkingVerbsPowerCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseLinkingVerbsPowerCommand>
    {
        public AbilityIncreaseLinkingVerbsPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}