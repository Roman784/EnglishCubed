using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseRageDodgeCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseRageDodgeCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.RageDodge;
    }

    public class AbilityIncreaseRageDodgeCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseRageDodgeCommand>
    {
        public AbilityIncreaseRageDodgeCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}