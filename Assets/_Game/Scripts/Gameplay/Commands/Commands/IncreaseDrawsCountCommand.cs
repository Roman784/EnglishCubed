
using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseDrawsCountCommand: IncreaseOneStatCommand
    {
        public IncreaseDrawsCountCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseDrawsCountCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseDrawsCountCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}