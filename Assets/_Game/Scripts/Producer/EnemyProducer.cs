using Configs;
using Gameplay;
using GameRoot;
using System.Collections.Generic;
using UnityEngine;

namespace GameProducer
{
    public class EnemyProducer
    {
        private GameProducerContext _context;

        private EnemiesConfigs Configs => G.Configs.EnemiesConfigs;
        private IReadOnlyList<EnemyConfigs> AllEnemies => Configs.AllEnemiesConfigs;

        public EnemyProducer(GameProducerContext context)
        {
            _context = context;
        }

        public EnemySpec GetEnemy()
        {
            var configs = AllEnemies[Random.Range(0, AllEnemies.Count - 1)];
            var health = CalculateHealth(configs.Rank);

            return new EnemySpec
            {
                EnemyConfigs = configs,
                Health = health
            };
        }

        private int CalculateHealth(EnemyRank rank)
        {
            var healthSpread = Configs.GetHealthSpread(rank);
            float health = Random.Range(healthSpread.Min, healthSpread.Max);
            health *= Configs.HealthConfigs.ChangesByStage.Evaluate(_context.StageProgress);
            return Mathf.RoundToInt(health / 5f) * 5;
        }
    }

    public class EnemySpec
    {
        public EnemyConfigs EnemyConfigs;
        public int Health;
    }
}