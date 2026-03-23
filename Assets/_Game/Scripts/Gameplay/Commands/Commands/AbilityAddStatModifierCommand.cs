using Gameplay;
using UnityEngine;

namespace Commands
{
    public abstract class AbilityAddStatModifierCommand : ICommand
    {
        public readonly StatModifier Modifier;
        public abstract StatName StatName { get; }

        public AbilityAddStatModifierCommand(StatModifier modifier)
        {
            Modifier = modifier;
        }
    }

    public abstract class AbilityAddStatModifierCommandHandler<TCommand> : 
        ICommandHandler<TCommand> where TCommand : AbilityAddStatModifierCommand
    {
        protected readonly Stats Stats;

        public AbilityAddStatModifierCommandHandler(Stats stats)
        {
            Stats = stats;
        }

        public virtual bool Handle(TCommand command)
        {
            Stats.AddModifier(command.StatName, command.Modifier);
            return true;
        }
    }
}