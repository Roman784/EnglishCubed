using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class PatternGrammarValidator: IGrammarValidator
    {
        private List<GrammarPattern> patterns;

        public PatternGrammarValidator()
        {
            patterns = BuildPatterns();
        }

        public bool Validate(string sentence)
        {
            sentence = sentence.Trim();

            bool isQuestion = sentence.EndsWith("?");
            bool isExclamation = sentence.EndsWith("!");

            if (isQuestion || isExclamation)
                sentence = sentence.Substring(0, sentence.Length - 1);

            var tokens = sentence.Split(' ');
            var words = new List<WordData>();

            foreach (var t in tokens)
            {
                if (!DictionaryData.Words.ContainsKey(t.ToLower()))
                    return false;

                words.Add(DictionaryData.Words[t.ToLower()]);
            }

            foreach (var pattern in patterns)
            {
                var match = pattern.Match(words);

                if (!match.Success)
                    continue;

                if (!CheckBeAgreement(match.Subject, match.Verb))
                    return false;

                return true;
            }

            return false;
        }

        private bool CheckBeAgreement(WordData subject, WordData verb)
        {
            if (subject == null || verb == null)
                return true;

            if (!verb.IsBeVerb)
                return true;

            string s = subject.Word;
            string v = verb.Word;

            if (v == "am" && s != "i") return false;
            if (v == "is" && !(s == "he" || s == "she")) return false;
            if (v == "are" && (s == "he" || s == "she" || s == "i")) return false;

            if (v == "was" && !(s == "i" || s == "he" || s == "she")) return false;
            if (v == "were" && (s == "he" || s == "she")) return false;

            return true;
        }

        private bool IsQuestionPattern(List<WordData> words)
        {
            if (words[0].PartOfSpeech == PartOfSpeech.WhWord)
                return true;

            if (words[0].IsBeVerb)
                return true;

            return false;
        }

        private List<GrammarPattern> BuildPatterns()
        {
            return new List<GrammarPattern>
            {
                // Present Simple – Affirmative.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            RequireNegative = true,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adverb,
                            Optional = true
                        }
                    }
                ),

                // Future – Affirmative.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            RequireModal = true
                        },
                        new PatternElement{
                            RequireNegative = true,
                            Optional = true
                        },
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adverb,
                            Optional = true
                        }
                    }
                ),

                // Yes/No Question – Present/Past.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            RequireNegative = true,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adverb,
                            Optional = true
                        }
                    }
                ),

                // Yes/No Future.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            RequireModal = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            RequireNegative = true,
                            Optional = true
                        },
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective,
                            Optional = true
                        }
                    }
                ),

                // WH Question – Present/Past.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.WhWord
                        },
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective,
                            Optional = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adverb,
                            Optional = true
                        }
                    }
                ),

                // WH Future.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.WhWord
                        },
                        new PatternElement{
                            RequireModal = true
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Pronoun,
                            role = GrammarRole.Subject
                        },
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        }
                    }
                ),

                // Imperative.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            RequireBe = true,
                            role = GrammarRole.Verb
                        },
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Adjective
                        }
                    }
                ),

                // Interjection.
                new GrammarPattern(
                    new List<PatternElement>
                    {
                        new PatternElement{
                            PartOfSpeech = PartOfSpeech.Interjection
                        }
                    }
                )
            };
        }
    }
}