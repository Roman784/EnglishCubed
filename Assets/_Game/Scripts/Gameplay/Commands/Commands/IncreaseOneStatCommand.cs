using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseOneStatCommand : ICommand
    {
        public readonly float Value;

        public IncreaseOneStatCommand(float value)
        {
            Value = value;
        }
    }

    public class IncreaseOneStatCommandHandler : ICommandHandler<IncreaseOneStatCommand>
    {
        private readonly Stat _stat;

        public IncreaseOneStatCommandHandler(Stat stat)
        {
            _stat = stat;
        }

        public bool Handle(IncreaseOneStatCommand command)
        {
            _stat.Add(command.Value);
            return true;
        }
    }
}