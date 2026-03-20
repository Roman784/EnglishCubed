using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseHandCapacityCommand : IncreaseOneStatCommand
    {
        public IncreaseHandCapacityCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseHandCapacityCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseHandCapacityCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}