using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public static class DictionaryData
    {
        public static Dictionary<string, WordData> Words =
        new Dictionary<string, WordData>()
    {
        // Pronouns
        { "i", new WordData("i", PartOfSpeech.Pronoun) },
        { "you", new WordData("you", PartOfSpeech.Pronoun) },
        { "he", new WordData("he", PartOfSpeech.Pronoun) },
        { "she", new WordData("she", PartOfSpeech.Pronoun) },
        { "we", new WordData("we", PartOfSpeech.Pronoun) },
        { "they", new WordData("they", PartOfSpeech.Pronoun) },

        // Be verbs
        { "am",  new WordData("am", PartOfSpeech.Verb){ IsBeVerb=true } },
        { "is",  new WordData("is", PartOfSpeech.Verb){ IsBeVerb=true } },
        { "are", new WordData("are", PartOfSpeech.Verb){ IsBeVerb=true } },
        { "was", new WordData("was", PartOfSpeech.Verb){ IsBeVerb=true } },
        { "were",new WordData("were", PartOfSpeech.Verb){ IsBeVerb=true } },
        { "be",  new WordData("be", PartOfSpeech.Verb){ IsBeVerb=true } },

        { "will", new WordData("will", PartOfSpeech.Verb){ IsModal=true } },
        { "not",  new WordData("not", PartOfSpeech.Adverb){ IsNegative=true } },

        // Adjectives
        { "clever", new WordData("clever", PartOfSpeech.Adjective) },
        { "wise", new WordData("wise", PartOfSpeech.Adjective) },
        { "good", new WordData("good", PartOfSpeech.Adjective) },
        { "beautiful", new WordData("beautiful", PartOfSpeech.Adjective) },
        { "stupid", new WordData("stupid", PartOfSpeech.Adjective) },
        { "careful", new WordData("careful", PartOfSpeech.Adjective) },

        { "here", new WordData("here", PartOfSpeech.Adverb) },
        { "there", new WordData("there", PartOfSpeech.Adverb) },

        { "who", new WordData("who", PartOfSpeech.WhWord) },
        { "where", new WordData("where", PartOfSpeech.WhWord) },
        { "what", new WordData("what", PartOfSpeech.WhWord) },

        { "wow", new WordData("wow", PartOfSpeech.Interjection) },
    };
    }
}