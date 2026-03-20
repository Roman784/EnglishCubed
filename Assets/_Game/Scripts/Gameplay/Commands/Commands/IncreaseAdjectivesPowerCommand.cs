using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseAdjectivesPowerCommand : IncreaseOneStatCommand
    {
        public IncreaseAdjectivesPowerCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseAdjectivesPowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseAdjectivesPowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}