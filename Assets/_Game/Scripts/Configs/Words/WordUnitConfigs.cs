using GrammarValidation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WordUnitConfigs",
                     menuName = "Game Configs/Lexicon/New Word Unit Configs")]
    public class WordUnitConfigs: ScriptableObject
    {
        public WordData Word;
    }
}