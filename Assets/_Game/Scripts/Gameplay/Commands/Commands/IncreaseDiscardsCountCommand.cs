using Gameplay;
using UnityEngine;

namespace Commands
{
    public class IncreaseDiscardsCountCommand: IncreaseOneStatCommand
    {
        public IncreaseDiscardsCountCommand(float value) : base(value)
        {
        }
    }

    public class IncreaseDiscardsCountCommandHandler : IncreaseOneStatCommandHandler
    {
        public IncreaseDiscardsCountCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}