using UnityEngine;

namespace GrammarValidation
{
    public class AuxiliaryMainVerbRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var aux = graph.Root.GetChild(DependencyRelation.Auxiliary);

            if (aux != null &&
                graph.Root.Token.Definition.IsVerb &&
                graph.Root.Token.Definition.VerbDefinition.Form != VerbForm.Base)
            {
                result.IsSuccess = false;
                result.Message = "Main verb after auxiliary must be in base form.";
                result.HintCode = 4;
                return false;
            }

            return true;
        }
    }
}