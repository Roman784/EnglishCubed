using GameRoot;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameConfigs", 
                     menuName = "Game Configs/New Game Configs", 
                     order = 0)]
    public class GameConfigs : ScriptableObject
    {
        public LexiconConfigs LexiconConfigs;
        public GrammarHintsConfigs GrammarHintsConfigs;
        public EncountersConfigs EncountersConfigs;
        public PointMultiplierNamesConfigs PointMultiplierNamesConfigs;
        public StatsConfigs StatsConfigs;
        public HeroesConfigs HeroesConfigs;
        public EnemiesConfigs EnemiesConfigs;
        public AbilitiesConfigs AbilitiesConfigs;
        public AudioConfigs AudioConfigs;
        public UIConfigs UIConfigs;
        public DefaultGameStateConfigs DefaultGameStateConfigs;
        public DefaultGameSessionDataConfigs DefaultGameSessionDataConfigs;
        public CurrencyConfigs CurrencyConfigs;
    }
}
