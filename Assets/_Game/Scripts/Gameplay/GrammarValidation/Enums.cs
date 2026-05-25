using UnityEngine;

namespace GrammarValidation
{
    public enum PartOfSpeech { Noun, Verb, Adjective, Pronoun, Auxiliary, Article, LinkingVerb, Preposition }
    public enum SentenceType { Affirmative, Interrogative, Exclamatory }
    public enum Number { Singular, Plural, Both, None }
    public enum Person { First, Second, Third, None }
    public enum VerbForm { Base, ThirdPersonSingular, Be_FirstSingular, Be_ThirdSingular, Be_Plural }

    public enum DependencyRelation { Root, Subject, Auxiliary, DirectObject, Complement, Article, Particle, Unknown }
}