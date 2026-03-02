using GrammarValidation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WordUnitConfigs",
                     menuName = "Game Configs/Grammar/New Word Unit Configs")]
    public class WordUnitConfigs: ScriptableObject
    {
        public int Points;
        public WordData Word;
    }
}