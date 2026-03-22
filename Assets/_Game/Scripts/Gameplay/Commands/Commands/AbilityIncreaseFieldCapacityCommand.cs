using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseFieldCapacityCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseFieldCapacityCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseFieldCapacityCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseFieldCapacityCommand>
    {
        public AbilityIncreaseFieldCapacityCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}