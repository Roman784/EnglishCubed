using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class ArticleUsageRule : IGrammarRule
    {
        public bool Execute(ParsedSentenceGraph graph, ValidationResult result)
        {
            var nodesToCheck = new List<SyntaxNode> { graph.Root };
            nodesToCheck.AddRange(graph.Root.Children);

            foreach (var node in nodesToCheck)
            {
                var article = node.GetChild(DependencyRelation.Article);
                if (article == null)
                    continue;

                string art = article.Token.RawValue.ToLower();

                if ((art == "a" || art == "an") && node.Token.Definition.Number == Number.Plural)
                {
                    result.IsSuccess = false;
                    result.Message = "A/An cannot be used with plural.";
                    result.HintCode = 1;
                    return false;
                }

                if (art == "a" && node.Token.Definition.StartsWithVowelSound)
                {
                    result.IsSuccess = false;
                    result.Message = "Use 'an' before vowel sound.";
                    result.HintCode = 1;
                    return false;
                }

                if (art == "an" && !node.Token.Definition.StartsWithVowelSound)
                {
                    result.IsSuccess = false;
                    result.Message = "Use 'a' before consonant sound.";
                    result.HintCode = 1;
                    return false;
                }
            }

            return true;
        }
    }
}