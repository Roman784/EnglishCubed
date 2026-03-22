using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseVampirismCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseVampirismCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.Vampirism;
    }

    public class AbilityIncreaseVampirismCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseVampirismCommand>
    {
        public AbilityIncreaseVampirismCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}