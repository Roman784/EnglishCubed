using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseHandCapacityCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseHandCapacityCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseHandCapacityCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseHandCapacityCommand>
    {
        public AbilityIncreaseHandCapacityCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}