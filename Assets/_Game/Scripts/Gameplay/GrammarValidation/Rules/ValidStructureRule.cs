using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class ValidStructureRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            if (graph.Root.Token == null)
            {
                result.IsSuccess = false;
                result.Message = "Missing main verb.";
                result.HintCode = 7;
                return false;
            }

            if (graph.Root.GetChild(DependencyRelation.Subject) == null)
            {
                result.IsSuccess = false;
                result.Message = "Missing or misplaced subject.";
                result.HintCode = 6;
                return false;
            }

            var orphans = graph.Root.GetChildren(DependencyRelation.Unknown);
            if (orphans.Any())
            {
                result.IsSuccess = false;
                result.Message = $"Structural error: Misplaced words like '{orphans.First().Token.RawValue}'.";
                result.HintCode = 0;
                return false;
            }

            return true;
        }
    }
}