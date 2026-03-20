using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseExclamatorySentencePowerCommand : IncreaseOneStatCommandHandler
    {
        public IncreaseExclamatorySentencePowerCommand(Stat stat) : base(stat)
        {
        }
    }

    public class IncreaseExclamatorySentencePowerCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseExclamatorySentencePowerCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}