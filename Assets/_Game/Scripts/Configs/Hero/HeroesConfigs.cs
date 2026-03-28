using Gameplay;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "HeroesConfigs",
                     menuName = "Game Configs/Heroes/New Heroes Configs",
                     order = 0)]
    public class HeroesConfigs : ScriptableObject
    {
        public HeroConfigs[] AllHeroesConfigs;

        public HeroConfigs GetHero(CreatureName name)
        {
            foreach (var hero in AllHeroesConfigs)
            {
                if (hero.Name == name)
                    return hero;
            }

            Debug.LogError($"Failed to find hero by name: {name}");
            return null;
        }
    }
}