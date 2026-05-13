using UnityEngine;

namespace GrammarValidation
{
    public class ValidationResult
    {
        public bool IsValid;
        public string Message;
        public int HintCode;

        public bool IsDeclarative;
        public bool IsInterrogative;
        public bool IsExclamatory;

        public bool HasPronouns;
        public bool HasAdjectives;
        public bool HasLinkinVerbs;

        public int WordsCount;

        public static ValidationResult Success(
            bool isDeclarative = false,
            bool isInterrogative = false, 
            bool isExclamatory = false,
            bool hasPronouns = false,
            bool hasAdjectives = false,
            bool hasLinkinVerbs = false,
            int wordsCount = 0)
            => new ValidationResult 
            { 
                IsValid = true,

                IsDeclarative = isDeclarative,
                IsInterrogative = isInterrogative,
                IsExclamatory = isExclamatory,

                HasPronouns = hasPronouns,
                HasAdjectives = hasAdjectives,
                HasLinkinVerbs = hasLinkinVerbs,
                WordsCount = wordsCount
            };

        public static ValidationResult Fail(string message, int hintCode)
            => new ValidationResult { IsValid = false, Message = message, HintCode = hintCode };
    }
}