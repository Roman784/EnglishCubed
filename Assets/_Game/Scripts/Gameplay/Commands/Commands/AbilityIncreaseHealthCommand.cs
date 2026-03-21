using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseHealthCommand : ICommand
    {
        public readonly int Value;

        public AbilityIncreaseHealthCommand(int value)
        {
            Value = value;
        }
    }

    public class AbilityIncreaseHealthCommandHandler : ICommandHandler<AbilityIncreaseHealthCommand>
    {
        private readonly Health _health;

        public AbilityIncreaseHealthCommandHandler(Health health)
        {
            _health = health;
        }

        public bool Handle(AbilityIncreaseHealthCommand command)
        {
            _health.SetMax(_health.Max + command.Value);
            return true;
        }
    }
}