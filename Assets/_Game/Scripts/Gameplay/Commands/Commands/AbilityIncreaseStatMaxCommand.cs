using Gameplay;
using UnityEngine;

namespace Commands
{
    public abstract class AbilityIncreaseStatMaxCommand : ICommand
    {
        public readonly float Value;

        public AbilityIncreaseStatMaxCommand(float value)
        {
            Value = value;
        }
    }

    public abstract class AbilityIncreaseStatMaxCommandHandler<TCommand> :
        ICommandHandler<TCommand> where TCommand : AbilityIncreaseStatMaxCommand
    {
        private readonly Stat _stat;

        public AbilityIncreaseStatMaxCommandHandler(Stat stat)
        {
            _stat = stat;
        }

        public bool Handle(TCommand command)
        {
            _stat.SetMax(_stat.Max + command.Value);
            return true;
        }
    }
}