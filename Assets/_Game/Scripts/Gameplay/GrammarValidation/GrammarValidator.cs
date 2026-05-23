using Configs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class GrammarValidator
    {
        private readonly Tokenizer _tokenizer;
        private readonly DependencyGraphBuilder _builder;
        private readonly List<IGrammarRule> _rules;
        private readonly SentenceAnalyzer _analyzer;

        public GrammarValidator()
        {
            _tokenizer = new Tokenizer();
            _builder = new DependencyGraphBuilder();
            _analyzer = new SentenceAnalyzer();

            _rules = new List<IGrammarRule>
            {
                new ValidStructureRule(),
                new TransitivityRule(),
                new SubjectVerbAgreementRule(),
                new AuxiliaryMainVerbRule(),
                new SingularNounArticleRule(),
                new ArticleUsageRule(),
                new ComplementAgreementRule()
            };
        }

        public ValidationResult Validate(string text)
        {
            var tokens = _tokenizer.Tokenize(text, out var type);
            var graph = _builder.BuildGraph(tokens, type);
            var result = new ValidationResult();

            foreach (var rule in _rules) 
            {
                if (!rule.Execute(graph, result)) 
                    break; 
            }

            _analyzer.Analyze(tokens, type, result);

            Debug.Log($"[{text} -> Got: {result.IsSuccess} " + (!result.IsSuccess ? $"({result.Message})" : ""));
            return result;
        }

        public void DebugSentence(string text, bool expected)
        {
            var tokens = _tokenizer.Tokenize(text, out var type);
            var graph = _builder.BuildGraph(tokens, type);
            var result = new ValidationResult();

            foreach (var rule in _rules) { if (!rule.Execute(graph, result)) break; }

            var isPassed = result.IsSuccess == expected;
            Debug.Log($"[{(isPassed ? "PASS" : "FAIL")}] {text} -> Expected: {expected}, Got: {result.IsSuccess} " + (!result.IsSuccess ? $"({result.Message})" : ""));
        }
    }
}