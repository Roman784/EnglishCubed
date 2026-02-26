using UnityEngine;

namespace GrammarValidation
{
    public enum SentenceType
    {
        None,
        Statement,
        Question
    }

    public enum PartOfSpeech
    {
        None,
        Noun,
        Verb,
        Pronoun,
        Article,
        Adjective,
        Adverb,
        Preposition,
        Conjunction,
        AuxiliaryVerb,
        ModalVerb
    }

    public enum Number
    {
        None,
        Singular,
        Plural,
        Uncountable
    }

    public enum Person
    {
        None,
        First,
        Second,
        Third
    }

    public enum Tense
    {
        None,
        Present,
        Past,
        Future
    }

    public enum VerbForm
    {
        None,
        Base,          // go
        ThirdPersonS,  // goes
        Past,          // went
        Gerund,        // going
        PastParticiple // gone
    }

    public enum Gender
    {
        None,
        Masculine,
        Feminine,
        Neutral
    }
}