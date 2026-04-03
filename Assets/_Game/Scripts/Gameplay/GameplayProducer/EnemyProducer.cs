using Configs;
using GameRoot;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class EnemyProducer
    {
        private EnemiesConfigs Configs => G.Configs.EnemiesConfigs;
        private IReadOnlyList<EnemyConfigs> AllEnemies => Configs.AllEnemiesConfigs;

        public EnemyProducer()
        {
        }

        public EnemySpec GetEnemy()
        {
            var configs = AllEnemies[Random.Range(0, AllEnemies.Count - 1)];
            var healthSpread = Configs.GetHealthSpread(configs.Rank);
            var health = Random.Range(healthSpread.Min, healthSpread.Max);
            health = Mathf.RoundToInt(health / 5f) * 5;

            return new EnemySpec
            {
                EnemyConfigs = configs,
                Health = health
            };
        }
    }

    public class EnemySpec
    {
        public EnemyConfigs EnemyConfigs;
        public int Health;
    }
}