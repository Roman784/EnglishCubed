using UnityEngine;

namespace GrammarValidation
{
    public class WordData
    {
        public string Word;
        public PartOfSpeech PartOfSpeech;

        public Morphology Morphology = new();
        public SyntaxProperties Syntax = new();

        public WordData(string word, PartOfSpeech pos)
        {
            Word = word;
            PartOfSpeech = pos;
        }
    }
}