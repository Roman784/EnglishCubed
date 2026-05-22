using Configs;
using GameRoot;
using System;
using System.Collections.Generic;

namespace GrammarValidation
{
    public class Tokenizer
    {
        LexiconConfigs Configs => G.Configs.LexiconConfigs;

        public List<Token> Tokenize(string text, out SentenceType type)
        {
            type = text.EndsWith("?") ? SentenceType.Interrogative : SentenceType.Affirmative;
            var words = text.Replace(".", "").Replace("?", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var tokens = new List<Token>();
            for (int i = 0; i < words.Length; i++)
            {
                tokens.Add(
                    new Token 
                    { 
                        RawValue = words[i], 
                        Definition = Configs.Lookup(words[i]).Definition, 
                        OriginalIndex = i 
                    });
            }
            return tokens;
        }
    }

    public class Token
    {
        public string RawValue { get; set; }
        public WordDefinition Definition { get; set; }
        public bool IsPunctuation { get; set; }
        public int OriginalIndex { get; set; }
    }
}