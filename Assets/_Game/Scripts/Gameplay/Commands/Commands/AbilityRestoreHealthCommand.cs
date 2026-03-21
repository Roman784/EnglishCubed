using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityRestoreHealthCommand : ICommand
    {
        public readonly int Value;
        public readonly bool Half;
        public readonly bool Full;

        public AbilityRestoreHealthCommand(int value = 0, bool half = false, bool full = false)
        {
            Value = value;
            Half = half;
            Full = full;
        }
    }

    public class AbilityRestoreHealthCommandHandler : ICommandHandler<AbilityRestoreHealthCommand>
    {
        private readonly Health _health;

        public AbilityRestoreHealthCommandHandler(Health health)
        {
            _health = health;
        }

        public bool Handle(AbilityRestoreHealthCommand command)
        {
            if (command.Full)
                _health.Restore(Mathf.FloorToInt(_health.Max - _health.CurrentValue));
            else if (command.Half)
                _health.Restore(Mathf.FloorToInt((_health.Max - _health.CurrentValue) / 2f));
            else
                _health.Restore(command.Value);
            return true;
        }
    }
}