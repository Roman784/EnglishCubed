using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseVampirismCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseVampirismCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Vampirism;
    }

    public class AbilityIncreaseVampirismCommandHandler : 
        AbilityAddModifierCommandHandler<AbilityIncreaseVampirismCommand>
    {
        public AbilityIncreaseVampirismCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}