using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class ParsedSentenceGraph
    {
        public SyntaxNode Root { get; set; }
        public SentenceType Type { get; set; }
    }

    public class SyntaxNode
    {
        public Token Token { get; set; }
        public DependencyRelation Relation { get; set; }
        public List<SyntaxNode> Children { get; set; } = new List<SyntaxNode>();

        public SyntaxNode GetChild(DependencyRelation rel) => Children.FirstOrDefault(c => c.Relation == rel);
        public List<SyntaxNode> GetChildren(DependencyRelation rel) => Children.Where(c => c.Relation == rel).ToList();
    }
}