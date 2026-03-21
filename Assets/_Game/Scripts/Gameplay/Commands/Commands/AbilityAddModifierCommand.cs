using Gameplay;
using UnityEngine;

namespace Commands
{
    public abstract class AbilityAddModifierCommand : ICommand
    {
        public readonly StatModifier Modifier;
        public abstract StatName StatName { get; }

        public AbilityAddModifierCommand(StatModifier modifier)
        {
            Modifier = modifier;
        }
    }

    public abstract class AbilityAddModifierCommandHandler : ICommandHandler<AbilityAddModifierCommand>
    {
        private readonly Stats _stats;

        public AbilityAddModifierCommandHandler(Stats stats)
        {
            _stats = stats;
        }

        public bool Handle(AbilityAddModifierCommand command)
        {
            _stats.AddModifier(command.StatName, command.Modifier);
            return true;
        }
    }
}