using Gameplay;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyHealthConfigs",
                     menuName = "Game Configs/Enemies/New Enemy Health Configs",
                     order = 2)]
    public class EnemyHealthConfigs : ScriptableObject
    {
        public HealthSpreadData OrdinaryEnemy;
        public HealthSpreadData LeaderEnemy;
        public HealthSpreadData BossEnemy;

        [Space]

        public AnimationCurve ChangesByStage;
    }
}