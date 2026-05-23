namespace GrammarValidation
{
    public class SubjectVerbAgreementRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var subject = graph.Root.GetChild(DependencyRelation.Subject);
            if (subject == null)
                return true;

            var sPerson = subject.Token.Definition.Person;
            var sNumber = subject.Token.Definition.Number;
            var verbToken = graph.Root.GetChild(DependencyRelation.Auxiliary)?.Token ?? graph.Root.Token;
            var vStr = verbToken.RawValue.ToLower();

            var isThirdSingular = sPerson == Person.Third && sNumber == Number.Singular;
            var isFirstSingular = sPerson == Person.First && sNumber == Number.Singular;

            if (vStr == "is" || vStr == "does" || vStr == "likes")
            {
                if (!isThirdSingular)
                {
                    result.IsSuccess = false;
                    result.Message = $"Verb '{vStr}' requires 3rd person singular subject.";
                    result.HintCode = 3;
                    return false;
                }
            }
            else if (vStr == "am")
            {
                if (!isFirstSingular)
                {
                    result.IsSuccess = false;
                    result.Message = "Verb 'am' requires 'I'.";
                    result.HintCode = 2;
                    return false;
                }
            }
            else if (vStr == "are")
            {
                if (isThirdSingular || isFirstSingular)
                {
                    result.IsSuccess = false;
                    result.Message = "Verb 'are' cannot be used with 1st/3rd person singular.";
                    result.HintCode = 2;
                    return false;
                }
            }
            else if (vStr == "do" || vStr == "like" || vStr == "walk" || vStr == "wake")
            {
                if (isThirdSingular)
                {
                    result.IsSuccess = false;
                    result.Message = $"Base verb '{vStr}' cannot be used with 3rd person singular.";
                    result.HintCode = 4;
                    return false;
                }
            }

            return true;
        }
    }
}