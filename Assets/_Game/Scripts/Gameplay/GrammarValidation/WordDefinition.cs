using System;
using UnityEngine;

namespace GrammarValidation
{
    [Serializable]
    public class WordDefinition
    {
        public string Text;
        public string Lemma;

        [Space]

        public PartOfSpeech Role;
        public bool StartsWithVowelSound;
        public Person Person;
        public Number Number;

        [Space]

        public bool IsVerb;
        public VerbDefinition VerbDefinition;
    }

    [Serializable]
    public class VerbDefinition
    {
        public VerbForm Form;
        public bool IsTransitive = true;
    }
}