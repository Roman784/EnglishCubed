using UnityEngine;

namespace GrammarValidation
{
    public enum PartOfSpeech
    {
        None, Noun, Verb, Pronoun, Article, Adjective, Adverb,
        Preposition, Conjunction, Interjection, Numeral, Determiner
    }

    public enum Number { None, Singular, Plural }
    public enum Person { None, First, Second, Third }
    public enum Tense { None, Present, Past, Future }
    public enum VerbForm { None, Base, ThirdPersonS, Past, Gerund, PastParticiple }
    public enum NounCase { None, Common, Possessive }
    public enum Aspect { None, Simple, Continuous, Perfect, PerfectContinuous }
    public enum Voice { None, Active, Passive }
    public enum Mood { None, Indicative, Imperative, Subjunctive }
    public enum PronounCase { None, Subject, Object, PossessiveDeterminer, PossessivePronoun, Reflexive }
    public enum PronounType { None, Personal, Possessive, Reflexive, Demonstrative, Interrogative, Relative, Indefinite }
    public enum Degree { None, Positive, Comparative, Superlative }
    public enum ArticleType { None, Definite, Indefinite }
}