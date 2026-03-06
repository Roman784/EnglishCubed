using UnityEngine;

namespace Gameplay
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private Transform _pointsAccumulationPoint;
        [SerializeField] private Transform[] _enemies;
        [SerializeField] private Hero _hero; // Temp.

        public Hero Hero => _hero;
        public Vector2 PointsAccumulationPosition => _pointsAccumulationPoint.position;
        public Vector2 FirstEnemyPosition => _enemies[0].position;
    }
}
