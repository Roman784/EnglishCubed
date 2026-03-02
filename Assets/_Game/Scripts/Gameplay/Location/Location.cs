using UnityEngine;

namespace Gameplay
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private Transform[] _enemies;

        public Vector2 Center => _centerPoint.position;
        public Vector2 FirstEnemyPosition => _enemies[0].position;
    }
}
