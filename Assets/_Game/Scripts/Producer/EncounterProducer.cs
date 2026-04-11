using Configs;
using EncountersMap;
using GameRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProducer
{
    public class EncounterProducer
    {
        private GameProducerContext _context;

        private EncountersConfigs Configs => G.Configs.EncountersConfigs;

        public EncounterProducer(GameProducerContext context)
        {
            _context = context;
        }

        public EncounterName GetEncounterName()
        {
            var encounetrs = Configs.AllEncountersConfigs
                .Where(e => e.Name != EncounterName.None && e.Name != EncounterName.BossCombat).ToArray();
            return WeightedRandom.Get(encounetrs.Select(e => (e.Name, e.Weight)).ToArray());
        }
    }
}