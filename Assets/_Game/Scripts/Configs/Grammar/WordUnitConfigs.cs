using GrammarValidation;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WordUnitConfigs",
                     menuName = "Game Configs/Grammar/New Word Unit Configs")]
    public class WordUnitConfigs: ScriptableObject
    {
        public int Weight;
        public int Points;
        public WordData Word;

        public string Name => Word.Text + Word.Lemma;
    }
}