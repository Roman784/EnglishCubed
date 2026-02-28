using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnityEngine;

namespace GrammarValidation
{
    public class GrammarRulesValidator
    {
        private readonly List<IGrammarRule> _rules;

        public GrammarRulesValidator()
        {
            _rules = new List<IGrammarRule>
            {
                new BasicStructureRule(),
                new PresentSimpleVerbAgreementRule(),
                new ArticleRule(),
                new ToBeAgreementRule(),
                new SubjectNumberAgreementRule(),
                new DoDoesRule()
            };
        }

        public ValidationResult Validate(SentenceNode sentence)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(sentence);
                if (!result.IsValid)
                    return result;
            }

            return ValidationResult.Success();
        }
    }
}