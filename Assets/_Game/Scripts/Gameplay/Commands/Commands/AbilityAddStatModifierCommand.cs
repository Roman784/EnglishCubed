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
        private readonly Stats _stats;

        public AbilityAddStatModifierCommandHandler(Stats stats)
        {
            _stats = stats;
        }

        public bool Handle(TCommand command)
        {
            _stats.AddModifier(command.StatName, command.Modifier);
            return true;
        }
    }
}