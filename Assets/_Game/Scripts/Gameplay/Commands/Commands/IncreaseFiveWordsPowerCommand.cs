using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseFiveWordsPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseFiveWordsPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseFiveWordsPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseFiveWordsPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}