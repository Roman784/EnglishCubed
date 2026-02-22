using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public static class DictionaryData 
    { 
        public static Dictionary<string, WordData> Words = new Dictionary<string, WordData>() 
        {
            { "i", CreateI() },
            { "you", CreateYou() },
            { "he", CreateHe() },
            { "she", CreateShe() },
            { "we", CreateWe() },
            { "they", CreateThey() },

            { "am", CreateAm() },
            { "is", CreateIs() },
            { "are", CreateAre() },

            { "clever", CreateClever() },
            { "wise", CreateWise() }
            /*{ "i", new WordData ("i", PartOfSpeech.Pronoun) }, 
            { "you", new WordData { Word = "you", PartOfSpeech = PartOfSpeech.Pronoun, Person = Person.Second } }, 
            { "he", new WordData { Word = "he", PartOfSpeech = PartOfSpeech.Pronoun, Person = Person.ThirdSingular } }, 
            { "she", new WordData { Word = "she", PartOfSpeech = PartOfSpeech.Pronoun, Person = Person.ThirdSingular } }, 
            { "we", new WordData { Word = "we", PartOfSpeech = PartOfSpeech.Pronoun, Person = Person.Plural } }, 
            { "they", new WordData { Word = "they", PartOfSpeech = PartOfSpeech.Pronoun, Person = Person.Plural } }, 

            { "am", new WordData { Word = "am", PartOfSpeech = PartOfSpeech.Verb, IsBeVerb = true, Tense = Tense.Present, Person = Person.FirstSingular } }, 
            { "is", new WordData { Word = "is", PartOfSpeech = PartOfSpeech.Verb, IsBeVerb = true, Tense = Tense.Present, Person = Person.ThirdSingular } }, 
            { "are", new WordData { Word = "are", PartOfSpeech = PartOfSpeech.Verb, IsBeVerb = true, Tense = Tense.Present, Person = Person.Plural } },

            { "clever", new WordData { Word = "clever", PartOfSpeech = PartOfSpeech.Adjective } },
            { "wise", new WordData { Word = "wise", PartOfSpeech = PartOfSpeech.Adjective } },
/*            
            { "was", new WordData { Word = "was", PartOfSpeech = PartOfSpeech.Verb, IsBeVerb = true, Tense = Tense.Past } }, 
            { "were", new WordData { Word = "were", PartOfSpeech = PartOfSpeech.Verb, IsBeVerb = true, Tense = Tense.Past } }, 
            
            { "will", new WordData { Word = "will", PartOfSpeech = PartOfSpeech.Modal, IsModal = true, Tense = Tense.Future } }, 
            
            { "do", new WordData { Word = "do", PartOfSpeech = PartOfSpeech.Verb, IsAuxiliary = true, Tense = Tense.Present } }, 
            { "does", new WordData { Word = "does", PartOfSpeech = PartOfSpeech.Verb, IsAuxiliary = true, Tense = Tense.Present, Person = Person.ThirdSingular } }, 
            { "did", new WordData { Word = "did", PartOfSpeech = PartOfSpeech.Verb, IsAuxiliary = true, Tense = Tense.Past } }, 
            
            { "see", new WordData { Word = "see", PartOfSpeech = PartOfSpeech.Verb, Tense = Tense.Present } }, 
            { "know", new WordData { Word = "know", PartOfSpeech = PartOfSpeech.Verb, Tense = Tense.Present } }, 

            { "not", new WordData { Word = "not", PartOfSpeech = PartOfSpeech.Particle, IsNegative = true } }, 
            
            { "and", new WordData { Word = "and", PartOfSpeech = PartOfSpeech.Conjunction } }, 
            
            { "clever", new WordData { Word = "clever", PartOfSpeech = PartOfSpeech.Adjective } }, 
            { "wise", new WordData { Word = "wise", PartOfSpeech = PartOfSpeech.Adjective } }, 
            
            { "here", new WordData { Word = "here", PartOfSpeech = PartOfSpeech.Adverb } }, 
            { "there", new WordData { Word = "there", PartOfSpeech = PartOfSpeech.Adverb } }, 
            
            { "who", new WordData { Word = "who", PartOfSpeech = PartOfSpeech.WhWord } }, 
            { "where", new WordData { Word = "where", PartOfSpeech = PartOfSpeech.WhWord } }, 
            { "what", new WordData { Word = "what", PartOfSpeech = PartOfSpeech.WhWord } } */
        };

        private static WordData CreateI()
        {
            var word = new WordData("I", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.First;
            word.Morphology.Number = Number.Singular;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateYou()
        {
            var word = new WordData("you", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.Second;
            word.Morphology.Number = Number.Singular;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateHe()
        {
            var word = new WordData("he", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.Third;
            word.Morphology.Number = Number.Singular;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateShe()
        {
            var word = new WordData("she", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.Third;
            word.Morphology.Number = Number.Singular;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateWe()
        {
            var word = new WordData("we", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.First;
            word.Morphology.Number = Number.Plural;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateThey()
        {
            var word = new WordData("they", PartOfSpeech.Pronoun);

            word.Morphology.Person = Person.Third;
            word.Morphology.Number = Number.Plural;
            word.Morphology.PronounCase = PronounCase.Subject;

            return word;
        }

        private static WordData CreateAm()
        {
            var word = new WordData("am", PartOfSpeech.Verb);

            word.Morphology.Tense = Tense.Present;
            word.Morphology.Person = Person.First;
            word.Morphology.Number = Number.Singular;
            word.Morphology.VerbForm = VerbForm.Base;

            word.Syntax.VerbType = VerbType.Linking;

            word.Syntax.AllowedPatterns.Add(
                new ValencyPattern(
                    SentenceRole.Subject,
                    SentenceRole.Verb,
                    SentenceRole.Complement
                )
            );

            return word;
        }

        private static WordData CreateIs()
        {
            var word = new WordData("is", PartOfSpeech.Verb);

            word.Morphology.Tense = Tense.Present;
            word.Morphology.Person = Person.Third;
            word.Morphology.Number = Number.Singular;
            word.Morphology.VerbForm = VerbForm.ThirdPersonSingular;

            word.Syntax.VerbType = VerbType.Linking;

            word.Syntax.AllowedPatterns.Add(
                new ValencyPattern(
                    SentenceRole.Subject,
                    SentenceRole.Verb,
                    SentenceRole.Complement
                )
            );

            return word;
        }

        private static WordData CreateAre()
        {
            var word = new WordData("are", PartOfSpeech.Verb);

            word.Morphology.Tense = Tense.Present;
            word.Morphology.VerbForm = VerbForm.Base;

            word.Syntax.VerbType = VerbType.Linking;

            word.Syntax.AllowedPatterns.Add(
                new ValencyPattern(
                    SentenceRole.Subject,
                    SentenceRole.Verb,
                    SentenceRole.Complement
                )
            );

            return word;
        }

        private static WordData CreateClever()
        {
            var word = new WordData("clever", PartOfSpeech.Adjective);

            word.Morphology.Degree = Degree.Positive;

            return word;
        }

        private static WordData CreateWise()
        {
            var word = new WordData("wise", PartOfSpeech.Adjective);

            word.Morphology.Degree = Degree.Positive;

            return word;
        }

    }
}