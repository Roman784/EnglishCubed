using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(
        fileName = "CurrencyConfigs",
        menuName = "Game Configs/Currency/New Currency Configs",
        order = 101)]
    public class CurrencyConfigs : ScriptableObject
    {
        public Vector2Int CoinsScatterForLevelPassing;
    }
}