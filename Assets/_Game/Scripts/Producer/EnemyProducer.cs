using Configs;
using EncountersMap;
using Gameplay;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.STP;

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
            if (G.SessionData.IsEnemyExist)
                return LoadSavedEnemy();
            return CreateNewEnemy();
        }

        private EnemySpec LoadSavedEnemy()
        {
            var name = G.SessionData.Enemy;
            return new EnemySpec
            {
                EnemyConfigs = Configs.GetEnemy(name),
                CurrentHealth = G.SessionData.CurrentEnemyHealth,
                MaxHealth = G.SessionData.MaxEnemyHealth
            };
        }

        private EnemySpec CreateNewEnemy()
        {
            var targetEnemyRank = GetEnemyRankByEncounter(_context.EncounterName);
            var targetEnemies = AllEnemies.Where(e => e.Rank == targetEnemyRank).ToArray();
            var configs = targetEnemies[Random.Range(0, targetEnemies.Length - 1)];
            var health = CalculateMaxHealth(configs.Rank);

            return new EnemySpec
            {
                EnemyConfigs = configs,
                CurrentHealth = health,
                MaxHealth = health
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

        private int CalculateMaxHealth(EnemyRank rank)
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
        public int CurrentHealth;
        public int MaxHealth;
    }
}