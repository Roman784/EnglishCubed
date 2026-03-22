using Gameplay;
using UnityEngine;

namespace Commands
{
    public class AbilityIncreaseDiscardsCountCommand : AbilityIncreaseStatMaxCommand
    {
        public AbilityIncreaseDiscardsCountCommand(float value) : base(value)
        {
        }
    }

    public class AbilityIncreaseDiscardsCountCommandHandler :
        AbilityIncreaseStatMaxCommandHandler<AbilityIncreaseDiscardsCountCommand>
    {
        public AbilityIncreaseDiscardsCountCommandHandler(Stat stat) : base(stat)
        {
        }
    }
}