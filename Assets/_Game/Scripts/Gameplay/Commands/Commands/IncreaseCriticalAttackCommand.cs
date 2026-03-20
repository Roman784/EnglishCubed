using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseCriticalAttackCommand : IncreaseOneStatCommand
    {
        public IncreaseCriticalAttackCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseCriticalAttackCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseCriticalAttackCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}