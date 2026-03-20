using Gameplay;

namespace Commands
{
    public class IncreaseArmorCommand : ICommand
    {
        public readonly int Value;

        public IncreaseArmorCommand(int value)
        {
            Value = value;
        }
    }

    public class IncreaseArmorCommandHandler : ICommandHandler<IncreaseArmorCommand>
    {
        private readonly Armor _armor;

        public IncreaseArmorCommandHandler(Armor armor)
        {
            _armor = armor;
        }

        public bool Handle(IncreaseArmorCommand command)
        {
            _armor.SetMax(_armor.Max + command.Value);
            return true;
        }
    }
}