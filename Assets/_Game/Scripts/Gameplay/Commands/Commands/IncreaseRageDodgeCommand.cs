using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseRageDodgeCommand : IncreaseOneStatCommand
    {
        public IncreaseRageDodgeCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseRageDodgeCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseRageDodgeCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}