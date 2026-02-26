using System;
using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    [Serializable]
    public class WordData
    {
        public string Text;

        [Space]

        public PartOfSpeech PartOfSpeech;

        [Header("For Nouns")]
        public Number Number;
        public bool IsCountable;

        [Header("For Pronouns")]
        public Person Person;
        public Gender Gender;

        [Space]

        [Header("For Verbs")]
        public Tense Tense;
        public VerbForm VerbForm;
        public bool IsLinkingVerb;
        public bool IsModal;

        public WordData(string text)
        {
            Text = text;
        }
    }
}