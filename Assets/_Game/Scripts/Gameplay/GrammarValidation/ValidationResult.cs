using UnityEngine;

namespace GrammarValidation
{
    public class ValidationResult
    {
        public bool IsValid;
        public string Message;
        public int HintCode;

        public static ValidationResult Success()
            => new ValidationResult { IsValid = true };

        public static ValidationResult Fail(string message, int hintCode)
            => new ValidationResult { IsValid = false, Message = message, HintCode = hintCode };
    }
}