using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseThreeWordsPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseThreeWordsPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseThreeWordsPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseThreeWordsPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}