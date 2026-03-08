using UnityEngine;

namespace Gameplay
{
    public class Enemy : Creature
    {
        [SerializeField] private Transform _centerPoint;

        public Vector2 Center => _centerPoint.position;

        public override void TakeDamage()
        {
        }
    }
}