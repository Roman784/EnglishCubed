using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseLinkingVerbsPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseLinkingVerbsPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseLinkingVerbsPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseLinkingVerbsPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}