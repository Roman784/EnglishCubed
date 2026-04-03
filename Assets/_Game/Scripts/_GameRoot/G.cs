using Abilities;
using Audio;
using Configs;
using Currency;
using Gameplay;
using GameSession;
using GameState;
using UI;
using UnityEngine;

namespace GameRoot
{
    public static class G
    {
        // Global.
        public static IConfigsProvider ConfigsProvider;
        public static Repository Repository;
        public static UIRoot UIRoot;
        public static PopUpsProvider PopUpsProvider;
        public static SceneProvider SceneProvider;
        public static AudioProvider AudioProvider;
        public static Wallet Wallet;
        public static GameSessionProvider GameSessionProvider;
        public static AbilityProvider AbilityProvider;

        // Gameplay.
        public static GameplayProducer Producer;
        public static CameraShaker CameraShaker;
        public static WordUnitsMovementProvider WordUnitsMovementProvider;
        public static WordUnitFactory WordUnitFactory;
        public static PointsFactory PointsFactory;

        public static GameConfigs Configs => ConfigsProvider.GameConfigs;
    }
}