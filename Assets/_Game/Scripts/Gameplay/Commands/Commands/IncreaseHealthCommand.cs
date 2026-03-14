using UnityEngine;

namespace Commands
{
    public class IncreaseHealthCommand : ICommand
    {
        public readonly int Value;

        public IncreaseHealthCommand(int value)
        {
            Value = value;
        }
    }
}