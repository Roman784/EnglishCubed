using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseFieldCapacityCommand : IncreaseOneStatCommand
    {
        public IncreaseFieldCapacityCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseFieldCapacityCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseFieldCapacityCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}