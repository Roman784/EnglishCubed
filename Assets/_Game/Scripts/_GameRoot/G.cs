using Audio;
using Commands;
using Configs;
using Gameplay;
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

        // Gameplay.
        public static CommandProcessor CommandProcessor;
        public static CameraShaker CameraShaker;
        public static WordUnitsMovementProvider WordUnitsMovementProvider;
        public static WordUnitFactory WordUnitFactory;
        public static PointsFactory PointsFactory;

        public static GameConfigs Configs => ConfigsProvider.GameConfigs;
    }
}