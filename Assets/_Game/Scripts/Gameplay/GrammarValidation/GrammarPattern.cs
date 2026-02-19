using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class GrammarPattern
    {
        private List<PatternElement> _elements;

        public GrammarPattern(List<PatternElement> elements)
        {
            _elements = elements;
        }

        public PatternMatchResult Match(List<WordData> words)
        {
            int wordIndex = 0;

            var result = new PatternMatchResult();

            foreach (var element in _elements)
            {
                if (wordIndex >= words.Count)
                {
                    if (element.Optional)
                        continue;
                    return new PatternMatchResult { Success = false };
                }

                var word = words[wordIndex];

                if (!element.Match(word))
                {
                    if (element.Optional)
                        continue;

                    return new PatternMatchResult { Success = false };
                }

                // 🔥 Назначаем роли
                if (element.role == GrammarRole.Subject)
                    result.Subject = word;

                if (element.role == GrammarRole.Verb)
                    result.Verb = word;

                wordIndex++;
            }

            if (wordIndex != words.Count)
                return new PatternMatchResult { Success = false };

            result.Success = true;
            return result;
        }
    }
}