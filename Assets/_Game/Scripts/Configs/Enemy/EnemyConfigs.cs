using Gameplay;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyConfigs",
                     menuName = "Game Configs/Enemies/New Enemy Configs",
                     order = 1)]
    public class EnemyConfigs : ScriptableObject
    {
        public CreatureName Name;
        public EnemyRank Rank;
        public Enemy Prefab;
    }
}