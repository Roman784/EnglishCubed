using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseAdjectivesPowerCommand : AbilityAddStatModifierCommand
    {
        public AbilityIncreaseAdjectivesPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.AdjectivesPower;
    }

    public class AbilityIncreaseAdjectivesPowerCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseAdjectivesPowerCommand>
    {
        public AbilityIncreaseAdjectivesPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}