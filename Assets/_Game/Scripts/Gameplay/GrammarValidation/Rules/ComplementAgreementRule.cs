using UnityEngine;

namespace GrammarValidation
{
    public class ComplementAgreementRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var subject = graph.Root.GetChild(DependencyRelation.Subject);
            var comp = graph.Root.GetChild(DependencyRelation.Complement);

            if (subject != null &&
                comp != null &&
                subject.Token.Definition.Role != PartOfSpeech.Adjective &&
                comp.Token.Definition.Role == PartOfSpeech.Noun)
            {
                if (subject.Token.Definition.Number != Number.Both &&
                    comp.Token.Definition.Number != Number.Both &&
                    subject.Token.Definition.Number != comp.Token.Definition.Number)
                {
                    result.IsSuccess = false;
                    result.Message = "Subject and Complement number mismatch.";
                    result.HintCode = 3;
                    return false;
                }
            }

            return true;
        }
    }
}