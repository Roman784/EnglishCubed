using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

namespace GrammarValidation
{
    public class PatternGrammarValidator: IGrammarValidator
    {
        private Dictionary<string, WordData> dictionary;

        public PatternGrammarValidator(Dictionary<string, WordData> dict)
        {
            dictionary = dict;
        }

        public bool Validate(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return false;

            var words = Tokenize(sentence);
            if (words == null || words.Count == 0)
                return false;

            var roles = AssignRoles(words);
            if (roles == null)
                return false;

            if (!HasSingleVerb(words))
                return false;

            if (!MatchVerbPattern(words, roles))
                return false;

            if (!ValidateAgreement(words, roles))
                return false;

            return true;
        }

        private List<WordData> Tokenize(string input)
        {
            input = input.ToLower().Trim();
            input = input.TrimEnd('.', '?', '!');

            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = new List<WordData>();

            foreach (var token in tokens)
            {
                if (!dictionary.ContainsKey(token))
                    return null;

                result.Add(dictionary[token]);
            }

            return result;
        }

        private List<SentenceRole> AssignRoles(List<WordData> words)
        {
            var roles = new List<SentenceRole>();

            int verbIndex = words.FindIndex(w => w.PartOfSpeech == PartOfSpeech.Verb);
            if (verbIndex == -1)
                return null;

            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];

                if (i == verbIndex)
                {
                    roles.Add(SentenceRole.Verb);
                    continue;
                }

                if (i < verbIndex)
                {
                    if (word.PartOfSpeech == PartOfSpeech.Noun ||
                        word.PartOfSpeech == PartOfSpeech.Pronoun)
                    {
                        roles.Add(SentenceRole.Subject);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (word.PartOfSpeech == PartOfSpeech.Adjective)
                    {
                        roles.Add(SentenceRole.Complement);
                    }
                    else if (word.PartOfSpeech == PartOfSpeech.Noun ||
                             word.PartOfSpeech == PartOfSpeech.Pronoun)
                    {
                        roles.Add(SentenceRole.DirectObject);
                    }
                    else if (word.PartOfSpeech == PartOfSpeech.Adverb)
                    {
                        roles.Add(SentenceRole.Adverbial);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return roles;
        }

        private bool HasSingleVerb(List<WordData> words)
        {
            return words.Count(w => w.PartOfSpeech == PartOfSpeech.Verb) == 1;
        }

        private bool MatchVerbPattern(List<WordData> words, List<SentenceRole> roles)
        {
            var verbIndex = words.FindIndex(w => w.PartOfSpeech == PartOfSpeech.Verb);
            var verb = words[verbIndex];

            foreach (var pattern in verb.Syntax.AllowedPatterns)
            {
                if (PatternMatches(pattern.Pattern, roles))
                    return true;
            }

            return false;
        }

        private bool PatternMatches(SentenceRole[] pattern, List<SentenceRole> roles)
        {
            if (pattern.Length != roles.Count)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != roles[i])
                    return false;
            }

            return true;
        }


        private bool ValidateAgreement(List<WordData> words, List<SentenceRole> roles)
        {
            var subjectIndex = roles.FindIndex(r => r == SentenceRole.Subject);
            var verbIndex = roles.FindIndex(r => r == SentenceRole.Verb);

            if (subjectIndex == -1 || verbIndex == -1)
                return false;

            var subject = words[subjectIndex];
            var verb = words[verbIndex];

            return CheckSubjectVerbAgreement(subject, verb);
        }

        public bool CheckSubjectVerbAgreement(WordData subject, WordData verb)
        {
            if (subject.Morphology.Person == Person.Third &&
                subject.Morphology.Number == Number.Singular)
            {
                return verb.Morphology.VerbForm ==
                       VerbForm.ThirdPersonSingular;
            }

            // Все остальные формы → Base
            return verb.Morphology.VerbForm == VerbForm.Base;
        }
    }
}