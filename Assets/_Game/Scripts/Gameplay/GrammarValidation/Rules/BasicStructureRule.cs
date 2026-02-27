using UnityEngine;

namespace GrammarValidation
{
    public class BasicStructureRule : IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            if (sentence.Subject == null)
                return ValidationResult.Fail("Sentence must have a subject.");

            if (sentence.Predicate == null || sentence.Predicate.Verb == null)
                return ValidationResult.Fail("Sentence must have a verb.");

            return ValidationResult.Success();
        }
    }
}