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
        public WordDefinition Definition;

        public string Name => Definition.Text + Definition.Lemma;
    }
}