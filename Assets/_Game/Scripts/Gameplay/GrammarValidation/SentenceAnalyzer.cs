using System.Collections.Generic;
using System.Linq;

namespace GrammarValidation
{
    public class SentenceAnalyzer
    {
        public void Analyze(IEnumerable<Token> tokens, SentenceType sentenceType, ValidationResult result)
        {
            result.IsDeclarative = sentenceType == SentenceType.Affirmative;
            result.IsInterrogative = sentenceType == SentenceType.Interrogative;
            result.IsExclamatory = sentenceType == SentenceType.Exclamatory;

            result.WordsCount = tokens.Count();

            result.HasPronouns = tokens.Any(t => t.Definition.Role == PartOfSpeech.Pronoun);
            result.HasAdjectives = tokens.Any(t => t.Definition.Role == PartOfSpeech.Adjective);
            result.HasLinkingVerbs = tokens.Any(t => t.Definition.Role == PartOfSpeech.LinkingVerb);
        }
    }
}