
using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDrawsCountCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseDrawsCountCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseDrawsCountCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseDrawsCountCommand>
    {
        public AbilityIncreaseDrawsCountCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}