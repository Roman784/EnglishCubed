using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseCriticalAttackPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseCriticalAttackPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseCriticalAttackPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseCriticalAttackPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}