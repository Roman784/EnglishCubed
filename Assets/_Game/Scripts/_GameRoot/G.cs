using Audio;
using Configs;
using GameState;
using UI;
using UnityEngine;

namespace GameRoot
{
    public static class G
    {
        public static IConfigsProvider ConfigsProvider;
        public static Repository Repository;
        public static UIRoot UIRoot;
        public static SceneProvider SceneProvider;
        public static AudioProvider AudioProvider;
    }
}