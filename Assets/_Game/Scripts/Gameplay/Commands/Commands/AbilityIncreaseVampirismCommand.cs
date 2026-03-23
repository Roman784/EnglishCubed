using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseVampirismCommand : AbilityAddStatModifierCommand
    {
        public readonly float AdditionalValue;

        public AbilityIncreaseVampirismCommand(StatModifier modifier, float additionalValue) : base(modifier)
        {
            AdditionalValue = additionalValue;
            Debug.Log($"Created AbilityIncreaseVampirismCommand with additional value: {additionalValue}");
        }

        public override StatName StatName => StatName.Vampirism;
    }

    public class AbilityIncreaseVampirismCommandHandler : 
        AbilityAddStatModifierCommandHandler<AbilityIncreaseVampirismCommand>
    {
        public AbilityIncreaseVampirismCommandHandler(Stats stats) : base(stats)
        {
        }

        public override bool Handle(AbilityIncreaseVampirismCommand command)
        {
            var stat = Stats.GetStat(StatName.VampirismPower);
            stat.SetMax(stat.Max + command.AdditionalValue);
            Debug.Log($"Vampirism power increased by {command.AdditionalValue}. New max: {stat.Max}");
            return base.Handle(command);
        }
    }
}