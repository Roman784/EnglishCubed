using UnityEngine;

namespace GrammarValidation
{
    public interface IGrammarRule
    {
        ValidationResult Validate(SentenceNode sentence);
    }
}