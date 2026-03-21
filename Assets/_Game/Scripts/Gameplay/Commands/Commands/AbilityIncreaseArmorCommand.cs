using Gameplay;

namespace Commands
{
    public class AbilityIncreaseArmorCommand : ICommand
    {
        public readonly int Value;

        public AbilityIncreaseArmorCommand(int value)
        {
            Value = value;
        }
    }

    public class AbilityIncreaseArmorCommandHandler : ICommandHandler<AbilityIncreaseArmorCommand>
    {
        private readonly Armor _armor;

        public AbilityIncreaseArmorCommandHandler(Armor armor)
        {
            _armor = armor;
        }

        public bool Handle(AbilityIncreaseArmorCommand command)
        {
            _armor.SetMax(_armor.Max + command.Value);
            return true;
        }
    }
}