using Gameplay;

namespace Commands
{
    public class AbilityIncreaseArmorCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseArmorCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseArmorCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseArmorCommand>
    {
        public AbilityIncreaseArmorCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}