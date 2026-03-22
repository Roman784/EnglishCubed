using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseHealthCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseHealthCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseHealthCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseHealthCommand>
    {
        public AbilityIncreaseHealthCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}