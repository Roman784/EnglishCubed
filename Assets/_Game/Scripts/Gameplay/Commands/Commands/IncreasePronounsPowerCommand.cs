using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreasePronounsPowerCommand : IncreaseOneStatCommand
    {
        public IncreasePronounsPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreasePronounsPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreasePronounsPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}