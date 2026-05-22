using UnityEngine;

namespace GrammarValidation
{
    public class TransitivityRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var directObj = graph.Root.GetChild(DependencyRelation.DirectObject);

            if (directObj != null &&
                graph.Root.Token.Definition.IsVerb &&
                !graph.Root.Token.Definition.VerbDefinition.IsTransitive)
            {
                result.IsSuccess = false;
                result.Message = $"Intransitive verb '{graph.Root.Token.RawValue}' cannot have a direct object '{directObj.Token.RawValue}'.";
                result.HintCode = 0;
                return false;
            }

            return true;
        }
    }
}