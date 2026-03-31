using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class ExperienceSaveData
    {
        public int CurrentValue;
        public int Level;

        public static ExperienceSaveData Create(Experience experience) =>
            new ExperienceSaveData()
            {
                CurrentValue = (int)experience.CurrentValue,
                Level = experience.CurrentLevel
            };
    }
}