using UnityEngine;

namespace GrammarValidation
{
    public interface IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result);
    }
}