using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseVampirismCommand : IncreaseOneStatCommand
    {
        public IncreaseVampirismCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseVampirismCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseVampirismCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}