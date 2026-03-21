using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityRestoreArmorCommand : ICommand
    {
        public readonly int Value;
        public readonly bool Half;
        public readonly bool Full;

        public AbilityRestoreArmorCommand(int value = 0, bool half = false, bool full = false)
        {
            Value = value;
            Half = half;
            Full = full;
        }
    }

    public class AbilityRestoreArmorCommandHandler : ICommandHandler<AbilityRestoreArmorCommand>
    {
        private readonly Armor _armor;

        public AbilityRestoreArmorCommandHandler(Armor armor)
        {
            _armor = armor;
        }

        public bool Handle(AbilityRestoreArmorCommand command)
        {
            if (command.Full)
                _armor.Restore(Mathf.FloorToInt(_armor.Max - _armor.CurrentValue));
            else if (command.Half)
                _armor.Restore(Mathf.FloorToInt((_armor.Max - _armor.CurrentValue) / 2f));
            else
                _armor.Restore(command.Value);
            return true;
        }
    }
}