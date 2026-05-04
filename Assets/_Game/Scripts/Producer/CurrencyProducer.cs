using Configs;
using GameRoot;
using UnityEngine;

namespace GameProducer
{
    public class CurrencyProducer
    {
        private GameProducerContext _context;

        private CurrencyConfigs Configs => G.Configs.CurrencyConfigs;

        public CurrencyProducer(GameProducerContext context)
        {
            _context = context;
        }

        public int GetCoinsForLevelPassing()
        {
            return Random.Range(Configs.CoinsScatterForLevelPassing.x, Configs.CoinsScatterForLevelPassing.y + 1);
        }
    }
}