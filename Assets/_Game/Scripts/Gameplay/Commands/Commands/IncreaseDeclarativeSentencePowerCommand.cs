using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseDeclarativeSentencePowerCommand : IncreaseOneStatCommand
    {
        public IncreaseDeclarativeSentencePowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseDeclarativeSentencePowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseDeclarativeSentencePowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}