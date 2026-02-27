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
                /*new ArticleRule(),
                new ArticleNumberAgreementRule(),
                new ToBeAgreementRule(),
                new QuestionAgreementRule()*/
            };
        }

        public ValidationResult Validate(SentenceNode sentence)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(sentence);
                if (!result.IsValid)
                {
                    Debug.Log($"Failed at {rule.GetType().Name}: {result.Message}");
                    return result;
                }
            }

            return ValidationResult.Success();
        }
    }
}