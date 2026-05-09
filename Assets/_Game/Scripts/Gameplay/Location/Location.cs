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
        [SerializeField] private Transform _enemyPoint;
        [SerializeField] private Transform _pointsAccumulationPoint;

        private Subject<Unit> _allEnemiesDeathSignalSubj = new();

        public Vector2 HeroPosition => _heroPoint.position;
        public Vector2 EnemyPosition => _enemyPoint.position;
        public Vector2 PointsAccumulationPosition => _pointsAccumulationPoint.position;

        public Observable<Unit> AllEnemiesDeathSignal => _allEnemiesDeathSignalSubj;
    }
}
