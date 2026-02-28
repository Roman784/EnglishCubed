using Configs;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UnityEngine;

namespace GrammarValidation
{
    public class GrammarValidator
    {
        private readonly Lexer _lexer;
        private readonly CFGParser _parser;
        private readonly GrammarRulesValidator _rulesValidator;

        public GrammarValidator(LexiconConfigs lexicon)
        {
            _lexer = new Lexer(lexicon);
            _parser = new CFGParser();
            _rulesValidator = new GrammarRulesValidator();
        }

        public ValidationResult Validate(string sentence)
        {
            var tokens = _lexer.Tokenize(sentence);
            if (tokens == null)
                return ValidationResult.Fail("Unknown word");

            var ast = _parser.Parse(tokens);
            if (ast == null)
                return ValidationResult.Fail("Syntax error");

            return _rulesValidator.Validate(ast);
        }

        public void DebugSentence(string sentence, bool expectedResult)
        {
            // Debug.Log($"=== Debug: {sentence} ===");
            var res = Validate(sentence);
            if (res.IsValid != expectedResult)
            {
                //Debug.Log($"Failed at {rule.GetType().Name}: {result.Message}");
                Debug.LogError($"Fail: {sentence}\nMust be: {expectedResult}\nMessage: {res.Message}\n" +
                    $"{_parser.Parse(_lexer.Tokenize(sentence))}");
            }
        }
    }
}