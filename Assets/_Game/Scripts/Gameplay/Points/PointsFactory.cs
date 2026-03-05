using UnityEngine;

namespace Gameplay
{
    public class PointsFactory
    {
        private Points _prefab;

        public PointsFactory()
        {
            _prefab = Resources.Load<Points>("Prefabs/Points");
        }

        public Points Create(float points, string sign, string message, Vector2 position)
        {
            var createdPoints = Object.Instantiate(_prefab, position, Quaternion.identity);

            createdPoints.Plus(points);
            createdPoints.SetSign(sign);
            createdPoints.SetMessage(message);
            createdPoints.Show();

            return createdPoints;
        }
    }
}