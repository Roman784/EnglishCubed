using System;
using UnityEngine;
using UnityEngine.Analytics;

namespace GrammarValidation
{
    [Serializable]
    public class WordData
    {
        public string Text;
        public string Lemma;
        public PartOfSpeech PartOfSpeech;

        [Space]

        public NounAttributes NounAttributes;
        public VerbAttributes VerbAttributes;
        public PronounAttributes PronounAttributes;
        public AdjectiveAttributes AdjectiveAttributes;
        public ArticleAttributes ArticleAttributes;

        public WordData(string text)
        {
            Text = text;
        }
    }

    [Serializable]
    public class NounAttributes
    {
        public Number Number;
        public bool IsCountable;
        public NounCase Case;
    }

    [Serializable]
    public class VerbAttributes
    {
        public Tense Tense;
        public Aspect Aspect;
        public VerbForm VerbForm;
        public Voice Voice;
        public Mood Mood;
        public Person Person;
        public Number Number;
        public bool IsMainVerb;
        public bool IsAuxiliary;
        public bool IsLinkingVerb; 
        public bool IsModal; 
        public bool IsTransitive; 
        public bool IsRegular; 
    }

    [Serializable]
    public class PronounAttributes
    {
        public Person Person;
        public PronounCase Case; 
        public PronounType Type; 
        public Number Number; 
    }

    [Serializable]
    public class AdjectiveAttributes
    {
        public Degree Degree;

        // Can added a syntactic role if needed
        // public bool IsAttributive; // "the big house"
        // public bool IsPredicative; // "the house is big"
    }

    [Serializable]
    public class ArticleAttributes
    {
        public ArticleType Type;
    }
}