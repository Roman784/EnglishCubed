using Configs;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProducer
{
    public class WordUnitsProducer
    {
        private readonly GameProducerContext _context;

        public WordUnitsProducer(GameProducerContext context)
        {
            _context = context;
        }

        public IEnumerable<WordUnitConfigs> GetThree()
        {
            return GetWords(3);
        }

        public IEnumerable<WordUnitConfigs> GetWords(int count)
        {
            var availableWords = new List<WordUnitConfigs>(_context.LexiconPool);
            var result = new List<WordUnitConfigs>();

            for (int i = 0; i < count; i++)
            {
                if (availableWords.Count == 0)
                    break;

                var weightedArray = availableWords
                    .Select(w => (item: w, weight: w.Weight))
                    .ToArray();

                var selected = WeightedRandom.Get(weightedArray);

                availableWords.Remove(selected);

                result.Add(selected);
            }

            return result;
        }
    }
}