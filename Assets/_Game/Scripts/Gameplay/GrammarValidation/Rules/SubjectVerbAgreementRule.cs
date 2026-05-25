namespace GrammarValidation
{
    public class SubjectVerbAgreementRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var subject = graph.Root.GetChild(DependencyRelation.Subject);

            if (subject == null)
                return true;

            var subjectDefinition = subject.Token.Definition;

            var sPerson = subjectDefinition.Person;
            var sNumber = subjectDefinition.Number;

            var verbToken =
                graph.Root.GetChild(DependencyRelation.Auxiliary)?.Token
                ?? graph.Root.Token;

            var verbDefinition = verbToken.Definition;

            if (!verbDefinition.IsVerb || verbDefinition.VerbDefinition == null)
                return true;

            var verbForm = verbDefinition.VerbDefinition.Form;

            var isThirdSingular =
                sPerson == Person.Third &&
                sNumber == Number.Singular;

            var isFirstSingular =
                sPerson == Person.First &&
                sNumber == Number.Singular;

            switch (verbForm)
            {
                case VerbForm.ThirdPersonSingular:

                    if (!isThirdSingular)
                    {
                        result.IsSuccess = false;
                        result.Message =
                            "This verb form requires a 3rd person singular subject.";
                        result.HintCode = 4;

                        return false;
                    }

                    break;

                case VerbForm.Base:

                    if (isThirdSingular)
                    {
                        result.IsSuccess = false;
                        result.Message =
                            "Base verb form cannot be used with 3rd person singular.";
                        result.HintCode = 4;

                        return false;
                    }

                    break;

                case VerbForm.Be_FirstSingular:

                    if (!isFirstSingular)
                    {
                        result.IsSuccess = false;
                        result.Message =
                            "'am' can only be used with first person singular.";
                        result.HintCode = 2;

                        return false;
                    }

                    break;

                case VerbForm.Be_ThirdSingular:

                    if (!isThirdSingular)
                    {
                        result.IsSuccess = false;
                        result.Message =
                            "'is' requires 3rd person singular.";
                        result.HintCode = 2;

                        return false;
                    }

                    break;

                case VerbForm.Be_Plural:

                    if (isFirstSingular || isThirdSingular)
                    {
                        result.IsSuccess = false;
                        result.Message =
                            "'are' cannot be used with 1st/3rd person singular.";
                        result.HintCode = 2;

                        return false;
                    }

                    break;
            }

            return true;
        }
    }
}