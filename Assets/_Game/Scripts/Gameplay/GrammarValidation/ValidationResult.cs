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
            bool isDeclarative = true,
            bool isInterrogative = true, 
            bool isExclamatory = true,
            bool hasPronouns = true,
            bool hasAdjectives = true,
            bool hasLinkinVerbs = true,
            int wordsCount = 3)
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