using UnityEngine;

namespace Gameplay
{
    public class HeroStats
    {
        public readonly Health Health;
        public readonly Armor Armor;
        public readonly Experience Experience;

        public HeroStats(Health health, Armor armor, Experience experience)
        {
            Health = health;
            Armor = armor;
            Experience = experience;
        }
    }
}