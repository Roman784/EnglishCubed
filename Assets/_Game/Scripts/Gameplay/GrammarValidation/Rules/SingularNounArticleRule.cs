using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class SingularNounArticleRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var nodesToCheck = new List<SyntaxNode> { graph.Root };
            nodesToCheck.AddRange(graph.Root.Children);

            foreach (var node in nodesToCheck)
            {
                if ((node.Relation == DependencyRelation.Subject ||
                     node.Relation == DependencyRelation.DirectObject ||
                     node.Relation == DependencyRelation.Complement) &&
                    node.Token.Definition.Role == PartOfSpeech.Noun &&
                    node.Token.Definition.Number == Number.Singular)
                {
                    if (node.GetChild(DependencyRelation.Article) == null)
                    {
                        result.IsSuccess = false;
                        result.Message = $"Singular noun '{node.Token.RawValue}' requires an article.";
                        result.HintCode = 1;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}