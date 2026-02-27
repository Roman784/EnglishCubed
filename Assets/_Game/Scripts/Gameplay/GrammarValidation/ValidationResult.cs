using UnityEngine;

namespace GrammarValidation
{
    public class ValidationResult
    {
        public bool IsValid;
        public string Message;

        public static ValidationResult Success()
            => new ValidationResult { IsValid = true };

        public static ValidationResult Fail(string message)
            => new ValidationResult { IsValid = false, Message = message };
    }
}