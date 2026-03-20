using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseInterrogativeSentenceMultiplierCommand : IncreaseOneStatCommand
    {
        public IncreaseInterrogativeSentenceMultiplierCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseInterrogativeSentenceMultiplierCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseInterrogativeSentenceMultiplierCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}