using Configs;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProducer
{
    public class WordUnitsProducer
    {
        private GameProducerContext _context;

        private LexiconConfigs Configs => G.Configs.LexiconConfigs;

        public WordUnitsProducer(GameProducerContext context)
        {
            _context = context;
        }

        public IEnumerable<WordUnitConfigs> GetWords(int count)
        {
            return Configs.AllWords.OrderBy(x => Random.value).Take(count);
        }
    }
}