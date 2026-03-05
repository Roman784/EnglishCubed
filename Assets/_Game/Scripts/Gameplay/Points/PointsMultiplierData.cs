using UnityEngine;

namespace Gameplay
{
    public class PointsMultiplierData
    {
        public readonly float Points;
        public readonly string Message;

        public PointsMultiplierData(float points, string message)
        {
            Points = points;
            Message = message;
        }
    }
}