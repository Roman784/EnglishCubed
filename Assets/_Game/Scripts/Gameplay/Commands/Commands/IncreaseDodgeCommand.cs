using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseDodgeCommand : IncreaseOneStatCommandHandler
    {
        public IncreaseDodgeCommand(Stat stat) : base(stat)
        {
        }
    }

    public class IncreaseDodgeCommandhandler : IncreaseOneStatCommandHandler
    {
        public IncreaseDodgeCommandhandler(Stat stat) : base(stat)
        {
        }
    }
}