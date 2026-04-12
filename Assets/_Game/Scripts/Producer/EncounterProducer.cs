using Configs;
using EncountersMap;
using GameRoot;
using System.Linq;

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
            var encounters = Configs.AllEncountersConfigs
                .Where(e => e.Name != EncounterName.None && e.Name != EncounterName.BossCombat).ToArray();
            return WeightedRandom.Get(encounters.Select(e => (e.Name, e.Weight)).ToArray());
        }
    }
}