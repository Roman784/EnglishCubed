using Audio;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AudioConfigs",
                     menuName = "Game Configs/Audio/New Audio Configs",
                     order = 3)]
    public class AudioConfigs : ScriptableObject
    {
        public AudioSourcer SourcerPrefab;
    }
}