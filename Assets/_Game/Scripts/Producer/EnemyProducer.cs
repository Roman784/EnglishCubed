using Configs;
using EncountersMap;
using Gameplay;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
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
            var targetEnemyRank = GetEnemyRankByEncounter(_context.EncounterName);
            var targetEnemies = AllEnemies.Where(e => e.Rank == targetEnemyRank).ToArray();
            var configs = targetEnemies[Random.Range(0, targetEnemies.Length - 1)];
            var health = CalculateHealth(configs.Rank);

            return new EnemySpec
            {
                EnemyConfigs = configs,
                Health = health
            };
        }

        private EnemyRank GetEnemyRankByEncounter(EncounterName encounterName)
        {
            switch (encounterName)
            {
                case EncounterName.BossCombat: return EnemyRank.Boss;
                case EncounterName.EmergencyCombat: return EnemyRank.Leader;
                default: return EnemyRank.Ordinary;
            }
        }

        private int CalculateHealth(EnemyRank rank)
        {
            var healthSpread = Configs.GetHealthSpread(rank);
            float health = Random.Range(healthSpread.Min, healthSpread.Max);
            health *= Configs.HealthConfigs.ChangesByStage.Evaluate(_context.PassedEncountersProgress);
            return Mathf.RoundToInt(health / 5f) * 5;
        }
    }

    public class EnemySpec
    {
        public EnemyConfigs EnemyConfigs;
        public int Health;
    }
}