using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseRageDodgeCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseRageDodgeCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.RageDodge;
    }

    public class AbilityIncreaseRageDodgeCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseRageDodgeCommand>
    {
        public AbilityIncreaseRageDodgeCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}