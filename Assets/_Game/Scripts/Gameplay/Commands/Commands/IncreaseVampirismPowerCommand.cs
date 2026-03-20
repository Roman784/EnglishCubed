using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseVampirismPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseVampirismPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseVampirismPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseVampirismPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}