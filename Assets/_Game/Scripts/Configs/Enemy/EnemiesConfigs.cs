using Gameplay;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemiesConfigs",
                     menuName = "Game Configs/Enemies/New Enemies Configs",
                     order = 0)]
    public class EnemiesConfigs : ScriptableObject
    {
        public EnemyConfigs[] AllEnemiesConfigs;
        public EnemyHealthConfigs HealthConfigs;

        public EnemyConfigs GetEnemy(CreatureName name)
        {
            foreach (var enemy in AllEnemiesConfigs)
            {
                if (enemy.Name == name)
                    return enemy;
            }

            Debug.LogError($"Failed to find enemy by name: {name}");
            return null;
        }

        public EnemyConfigs GetEnemy(EnemyRank rank)
        {
            foreach (var enemy in AllEnemiesConfigs)
            {
                if (enemy.Rank == rank)
                    return enemy;
            }

            Debug.LogError($"Failed to find enemy by rank: {rank}");
            return null;
        }

        public HealthSpreadData GetHealthSpread(EnemyRank rank)
        {
            return rank switch
            {
                EnemyRank.Ordinary => HealthConfigs.OrdinaryEnemy,
                EnemyRank.Leader => HealthConfigs.LeaderEnemy,
                EnemyRank.Boss => HealthConfigs.BossEnemy,
                _ => throw new System.Exception($"Unsupported enemy rank: {rank}!")
            };
        }
    }
}