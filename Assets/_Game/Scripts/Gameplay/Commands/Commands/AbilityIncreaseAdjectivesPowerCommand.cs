using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseAdjectivesPowerCommand : AbilityAddModifierCommand
    {
        public AbilityIncreaseAdjectivesPowerCommand(StatModifier modifier) : base(modifier)
        {
        }

        public override StatName StatName => StatName.AdjectivesPower;
    }

    public class AbilityIncreaseAdjectivesPowerCommandHandler : AbilityAddModifierCommandHandler
    {
        public AbilityIncreaseAdjectivesPowerCommandHandler(Stats stats) : base(stats)
        {
        }
    }
}