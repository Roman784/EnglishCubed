using Audio;
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
        public static SceneProvider SceneProvider;
        public static AudioProvider AudioProvider;

        // Gameplay.
        public static HandWordUnitsGroup HandWordUnitsGroup;
        public static FieldWordUnitsGroup FieldWordUnitsGroup;
    }
}