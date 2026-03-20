using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseFourWordsPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseFourWordsPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseFourWordsPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseFourWordsPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}