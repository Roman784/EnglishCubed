using Configs;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GrammarValidation
{
    public class ParsedSentence
    {
        public readonly IEnumerable<Token> Tokens;
        public readonly char TerminalPunctuation;

        public ParsedSentence(IEnumerable<Token> tokens, char terminalPunctuation)
        {
            Tokens = new List<Token>(tokens);
            TerminalPunctuation = terminalPunctuation;
        }

        public override string ToString()
        {
            var sentence = "";
            foreach (var token in Tokens)
                sentence += $"[{token.Lexeme.Text}]";
            sentence += $"[{TerminalPunctuation}]";
            return sentence;
        }
    }

    public class Token
    {
        public readonly WordData Lexeme;
        public readonly int Position;

        public Token(WordData lexeme, int position)
        {
            Lexeme = lexeme;
            Position = position;
        }
    }

    public class Lexer
    {
        private readonly LexiconConfigs _lexicon;

        public Lexer(LexiconConfigs lexicon)
        {
            _lexicon = lexicon;
        }

        public ParsedSentence Tokenize(string sentence)
        {
            if (sentence.Length == 0) return null;

            var tokens = new List<Token>();
            var terminalPunctuation = GetTerminalPunctuation(sentence);

            sentence = Normalize(sentence);
            var words = sentence.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                var wordText = words[i];
                var lexeme = _lexicon.Lookup(wordText).Word;

                if (lexeme == null)
                {
                    Debug.LogError($"Word {wordText} not found in the lexicon!");
                    continue;
                }

                tokens.Add(new Token(lexeme, i));
            }

            return new ParsedSentence(tokens, terminalPunctuation);
        }

        private char GetTerminalPunctuation(string sentence)
        {
            var lastChar = sentence.Last();
            switch (lastChar)
            {
                case '?': return '?';
                case '!': return '!';
            }
            return '.';
        }

        private string Normalize(string sentence)
        {
            sentence = sentence.ToLower();
            sentence = Regex.Replace(sentence, @"[^\w\s]", "");
            sentence = Regex.Replace(sentence, @"\s+", " ");
            return sentence.Trim();
        }
    }
}