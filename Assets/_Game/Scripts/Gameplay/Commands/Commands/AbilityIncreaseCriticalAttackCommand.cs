using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseCriticalAttackCommand : AbilityAddStatModifierCommand
    {
        public readonly float AdditionalValue;

        public AbilityIncreaseCriticalAttackCommand(StatModifier modifier, float additionalValue) : base(modifier)
        {
            AdditionalValue = additionalValue;
        }

        public override StatName StatName => StatName.CriticalAttack;
    }

    public class AbilityIncreaseCriticalAttackCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseCriticalAttackCommand>
    {
        public AbilityIncreaseCriticalAttackCommandHandler(Stats stats) : base(stats)
        {
        }

        public override bool Handle(AbilityIncreaseCriticalAttackCommand command)
        {
            var stat = Stats.GetStat(StatName.CriticalAttackPower);
            stat.SetMax(stat.Max + command.AdditionalValue);
            return base.Handle(command);
        }
    }
}