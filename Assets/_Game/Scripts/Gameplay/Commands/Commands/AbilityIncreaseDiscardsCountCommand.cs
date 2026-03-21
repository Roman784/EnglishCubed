using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDiscardsCountCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseDiscardsCountCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.DiscardsCount;
    }

    public class AbilityIncreaseDiscardsCountCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseDiscardsCountCommand>
    {
        public AbilityIncreaseDiscardsCountCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}