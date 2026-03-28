using Gameplay;
using System;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "HeroConfigs",
                     menuName = "Game Configs/Heroes/New Hero Configs",
                     order = 1)]
    public class HeroConfigs : ScriptableObject
    {
        public CreatureName Name;
        public Hero Prefab;

        [Space]

        [TextArea(2, 2)] public string NameDescription;
        [TextArea(4, 5)] public string DetailsDescription;

        [Space]

        public int Price;

        [Space]

        public StatData[] InitialStats;

        public int Health => Mathf.CeilToInt(InitialStats.FirstOrDefault(s => s.Name == StatName.Health)?.Value ?? 1);
        public int Armor => Mathf.CeilToInt(InitialStats.FirstOrDefault(s => s.Name == StatName.Armor)?.Value ?? 1);
    }
}