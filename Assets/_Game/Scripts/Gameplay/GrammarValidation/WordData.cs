using UnityEngine;

namespace GrammarValidation
{
    public class WordData
    {
        public string Word;
        public PartOfSpeech PartOfSpeech;

        public bool IsBeVerb;
        public bool IsModal;
        public bool IsNegative;

        public WordData(string word, PartOfSpeech partOfSpeech)
        {
            Word = word;
            PartOfSpeech = partOfSpeech;
        }
    }
}