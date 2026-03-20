using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseRageAttackCommand : IncreaseOneStatCommand
    {
        public IncreaseRageAttackCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseRageAttackCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseRageAttackCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}