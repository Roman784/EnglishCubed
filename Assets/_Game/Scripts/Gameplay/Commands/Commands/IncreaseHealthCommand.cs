using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseHealthCommand : ICommand
    {
        public readonly int Value;

        public IncreaseHealthCommand(int value)
        {
            Value = value;
        }
    }

    public class IncreaseHealthCommandHandler : ICommandHandler<IncreaseHealthCommand>
    {
        private readonly Health _health;

        public IncreaseHealthCommandHandler(Health health)
        {
            _health = health;
        }

        public bool Handle(IncreaseHealthCommand command)
        {
            _health.SetMax(_health.Max + command.Value);
            return true;
        }
    }
}