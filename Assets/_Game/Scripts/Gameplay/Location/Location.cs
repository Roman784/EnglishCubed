using Configs;
using GameRoot;
using R3;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private Transform _heroPoint;
        [SerializeField] private Transform _pointsAccumulationPoint;
        [SerializeField] private List<Enemy> _enemies;

        private Subject<Unit> _allEnemiesDeathSignalSubj = new();

        public Vector2 HeroPosition => _heroPoint.position;
        public Vector2 PointsAccumulationPosition => _pointsAccumulationPoint.position;
        public Enemy FirstEnemy => _enemies[0];

        public Observable<Unit> AllEnemiesDeathSignal => _allEnemiesDeathSignalSubj;

        private void Start()
        {
            foreach (var enemy in _enemies)
            {
                var stats = new Stats(new Health(50));
                enemy.Init(stats);

                enemy.DeathSignal.Subscribe(_ =>
                {
                    _enemies.Remove(enemy);

                    if (_enemies.Count == 0)
                    {
                        _allEnemiesDeathSignalSubj.OnNext(Unit.Default);
                        _allEnemiesDeathSignalSubj.OnCompleted();
                    }
                });
            }
        }
    }
}
