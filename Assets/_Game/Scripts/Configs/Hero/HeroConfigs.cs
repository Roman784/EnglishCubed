using Gameplay;
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
    }
}