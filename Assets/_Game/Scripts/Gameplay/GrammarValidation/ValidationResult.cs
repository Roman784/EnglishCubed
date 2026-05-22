namespace GrammarValidation
{
    public class ValidationResult
    {
        public bool IsSuccess = true;
        public string Message;
        public int HintCode;

        public bool IsDeclarative;
        public bool IsInterrogative;
        public bool IsExclamatory;

        public bool HasPronouns;
        public bool HasAdjectives;
        public bool HasLinkinVerbs;

        public int WordsCount;
    }
}