using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseExperienceMultiplierCommand : IncreaseOneStatCommand
    {
        public IncreaseExperienceMultiplierCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseExperienceMultiplierCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseExperienceMultiplierCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}