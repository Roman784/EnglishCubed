using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace GrammarValidation
{
    public class CFGParser
    {
        private TokenizedSentence _sentence;
        private int _pointer;

        public SentenceNode Parse(TokenizedSentence tokenizedSentence)
        {
            _sentence = tokenizedSentence;
            _pointer = 0;

            var sentenceNode = ParseSentence();

            if (!IsAtEnd())
            {
                Debug.LogError("Unexpected tokens at end of sentence.");
                return null;
            }

            return sentenceNode;
        }

        private List<Token> Tokens() => _sentence.Tokens;
        private Token Peek() => _pointer < Tokens().Count ? Tokens()[_pointer] : null;
        private Token Consume() => Tokens()[_pointer++];
        private bool IsAtEnd() => _pointer >= Tokens().Count;

        private SentenceNode ParseSentence()
        {
            if (_sentence.TerminalPunctuation == '?')
                return ParseQuestion();
            return ParseStatement();
        }

        private SentenceNode ParseQuestion()
        {
            var sentence = new SentenceNode();
            sentence.IsQuestion = true;

            if (Peek() == null)
            {
                Debug.LogError("Unexpected end of input in question!");
                return null;
            }

            var lexeme = Peek().Lexeme;
            if (lexeme.VerbAttributes.IsLinkingVerb)
                ParseLinkingVerbQuestion(sentence);
            else if (lexeme.VerbAttributes.IsAuxiliary)
                ParseDoDoesQuestion(sentence);
            else
            {
                Debug.Log("Failed to parse the question!");
                return null;
            }

            return sentence;
        }

        private SentenceNode ParseStatement()
        {
            var sentence = new SentenceNode();

            sentence.Subject = ParseSubject();
            sentence.Predicate = ParsePredicate();

            return sentence;
        }

        private void ParseLinkingVerbQuestion(SentenceNode sentence)
        {
            // Linking verb.
            var linkingVerb = Consume().Lexeme;
            sentence.Auxiliary = linkingVerb;

            // Subject.
            sentence.Subject = ParseSubject();

            // Predicate with linking verb.
            sentence.Predicate = new PredicateNode
            {
                Verb = linkingVerb
            };

            // Complement.
            ParseLinkingComplement(sentence.Predicate);
        }

        private void ParseDoDoesQuestion(SentenceNode sentence)
        {
            // Auxiliary (do/does).
            sentence.Auxiliary = Consume().Lexeme;

            // Subject.
            sentence.Subject = ParseSubject();

            // Base verb.
            if (Peek()?.Lexeme.PartOfSpeech != PartOfSpeech.Verb)
            {
                Debug.LogError("Expected base verb in question!");
                return;
            }

            var verb = Consume().Lexeme;

            /*if (verb.VerbAttributes.VerbForm == VerbForm.ThirdPersonS)
            {
                Debug.LogError("Use base form verb in questions!");
                return;
            }*/

            sentence.Predicate = new PredicateNode
            {
                Verb = verb
            };

            // Optional object.
            var nounPhrase = TryParseNounPhrase();
            if (nounPhrase != null)
                sentence.Predicate.Objects = nounPhrase.Words;
        }

        private SubjectNode ParseSubject()
        {
            var token = Peek();

            if (token == null)
            {
                Debug.LogError("Expected subject!");
                return null;
            }

            if (token.Lexeme.PartOfSpeech == PartOfSpeech.Pronoun)
            {
                var node = new SubjectNode();
                node.Words.Add(Consume().Lexeme);
                return node;
            }

            return ParseNounPhrase();
        }

        private SubjectNode ParseNounPhrase()
        {
            var result = TryParseNounPhrase();
            if (result == null)
                throw new Exception("Expected noun in noun phrase.");
            return result;
        }

        private SubjectNode TryParseNounPhrase()
        {
            var start = _pointer;
            var nounPhrase = new SubjectNode();

            // Article (optional).
            if (Peek()?.Lexeme.PartOfSpeech == PartOfSpeech.Article)
                nounPhrase.Words.Add(Consume().Lexeme);

            // Adjectives (optional).
            while (Peek()?.Lexeme.PartOfSpeech == PartOfSpeech.Adjective)
                nounPhrase.Words.Add(Consume().Lexeme);

            // Noun (required).
            if (Peek()?.Lexeme.PartOfSpeech == PartOfSpeech.Noun)
            {
                nounPhrase.Words.Add(Consume().Lexeme);
                return nounPhrase;
            }

            // Rollback if no noun.
            _pointer = start;
            return null;
        }

        private PredicateNode ParsePredicate()
        {
            var predicate = new PredicateNode();

            if (Peek()?.Lexeme.PartOfSpeech != PartOfSpeech.Verb)
            {
                Debug.LogError("Expected verb!");
                return null;
            }

            predicate.Verb = Consume().Lexeme;

            // Linking verb - complement.
            if (predicate.Verb.VerbAttributes.IsLinkingVerb)
            {
                ParseLinkingComplement(predicate);
                return predicate;
            }

            // Otherwise - optional object.
            var nounPhrase = TryParseNounPhrase();
            if (nounPhrase != null)
                predicate.Objects = nounPhrase.Words;

            return predicate;
        }

        private void ParseLinkingComplement(PredicateNode predicate)
        {
            if (IsAtEnd())
            {
                Debug.LogError("Expected complement after linking verb!");
                return;
            }

            // Adjective.
            if (Peek().Lexeme.PartOfSpeech == PartOfSpeech.Adjective)
            {
                predicate.Complement = Consume().Lexeme;
                return;
            }

            // NounPhrase.
            var nounPhrase = TryParseNounPhrase();
            if (nounPhrase != null)
            {
                predicate.Objects = nounPhrase.Words;
                return;
            }

            Debug.LogError("Invalid complement after linking verb!");
        }
    }
}