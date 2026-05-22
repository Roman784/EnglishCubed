using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class DependencyGraphBuilder
    {
        public ParsedSentenceGraph BuildGraph(List<Token> tokens, SentenceType type)
        {
            var graph = new ParsedSentenceGraph { Type = type };
            var root = new SyntaxNode { Relation = DependencyRelation.Root };
            var unattached = tokens.Select(t => new SyntaxNode { Token = t }).ToList();

            AttachArticles(unattached);
            AttachPhrasalVerbs(unattached);

            var (mainVerb, auxVerb) = ExtractMainAndAuxiliaryVerbs(unattached);

            if (mainVerb == null)
            {
                AttachOrphans(root, unattached);
                graph.Root = root;
                return graph;
            }

            SetupRoot(root, mainVerb, auxVerb);
            AttachSubject(unattached, root, auxVerb, type);
            AttachComplement(unattached, root);
            AttachOrphans(root, unattached);

            graph.Root = root;
            return graph;
        }

        private void AttachArticles(List<SyntaxNode> unattached)
        {
            for (int i = 0; i < unattached.Count - 1; i++)
            {
                if (unattached[i].Token.Definition.Role == PartOfSpeech.Article &&
                   (unattached[i + 1].Token.Definition.Role == PartOfSpeech.Noun || unattached[i + 1].Token.Definition.Role == PartOfSpeech.Adjective))
                {
                    unattached[i].Relation = DependencyRelation.Article;
                    unattached[i + 1].Children.Add(unattached[i]);
                    unattached.RemoveAt(i);
                    i--;
                }
            }
        }

        private void AttachPhrasalVerbs(List<SyntaxNode> unattached)
        {
            for (int i = 0; i < unattached.Count - 1; i++)
            {
                if (unattached[i].Token.Definition.Role == PartOfSpeech.Verb && unattached[i + 1].Token.Definition.Role == PartOfSpeech.Preposition)
                {
                    unattached[i + 1].Relation = DependencyRelation.Particle;
                    unattached[i].Children.Add(unattached[i + 1]);
                    unattached.RemoveAt(i + 1);
                }
            }
        }

        private (SyntaxNode mainVerb, SyntaxNode auxVerb) ExtractMainAndAuxiliaryVerbs(List<SyntaxNode> unattached)
        {
            SyntaxNode mainVerb = null;
            SyntaxNode auxVerb = null;

            var v1 = unattached.FirstOrDefault(n => n.Token.Definition.Role == PartOfSpeech.Verb || n.Token.Definition.Role == PartOfSpeech.Auxiliary || n.Token.Definition.Role == PartOfSpeech.LinkingVerb);
            if (v1 != null)
            {
                if (v1.Token.Definition.Role == PartOfSpeech.Auxiliary)
                {
                    auxVerb = v1;
                    unattached.Remove(v1);
                    mainVerb = unattached.FirstOrDefault(n => n.Token.Definition.Role == PartOfSpeech.Verb || n.Token.Definition.Role == PartOfSpeech.LinkingVerb);
                    if (mainVerb != null) unattached.Remove(mainVerb);
                    else { mainVerb = auxVerb; auxVerb = null; }
                }
                else
                {
                    mainVerb = v1;
                    unattached.Remove(v1);
                }
            }

            return (mainVerb, auxVerb);
        }

        private void SetupRoot(SyntaxNode root, SyntaxNode mainVerb, SyntaxNode auxVerb)
        {
            root.Token = mainVerb.Token;
            root.Children.AddRange(mainVerb.Children);
            if (auxVerb != null)
            {
                auxVerb.Relation = DependencyRelation.Auxiliary;
                root.Children.Add(auxVerb);
            }
        }

        private void AttachSubject(List<SyntaxNode> unattached, SyntaxNode root, SyntaxNode auxVerb, SentenceType type)
        {
            SyntaxNode subject = null;
            foreach (var n in unattached.Where(x => x.Token.Definition.Role == PartOfSpeech.Noun || x.Token.Definition.Role == PartOfSpeech.Pronoun).ToList())
            {
                bool isValidPos = false;
                if (type == SentenceType.Interrogative)
                {
                    if (auxVerb != null)
                    {
                        isValidPos = n.Token.OriginalIndex > auxVerb.Token.OriginalIndex && n.Token.OriginalIndex < root.Token.OriginalIndex;
                    }
                    else if (root.Token.Definition.Role == PartOfSpeech.LinkingVerb)
                    {
                        isValidPos = n.Token.OriginalIndex > root.Token.OriginalIndex;
                    }
                }
                else
                {
                    int verbIndex = auxVerb != null ? auxVerb.Token.OriginalIndex : root.Token.OriginalIndex;
                    isValidPos = n.Token.OriginalIndex < verbIndex;
                }

                if (isValidPos)
                {
                    subject = n;
                    break;
                }
            }

            if (subject != null)
            {
                subject.Relation = DependencyRelation.Subject;
                root.Children.Add(subject);
                unattached.Remove(subject);
            }
        }

        private void AttachComplement(List<SyntaxNode> unattached, SyntaxNode root)
        {
            var objComp = unattached.FirstOrDefault(n =>
                (n.Token.Definition.Role == PartOfSpeech.Noun || n.Token.Definition.Role == PartOfSpeech.Pronoun || n.Token.Definition.Role == PartOfSpeech.Adjective) &&
                n.Token.OriginalIndex > root.Token.OriginalIndex);

            if (objComp != null)
            {
                objComp.Relation = root.Token.Definition.Role == PartOfSpeech.LinkingVerb ? DependencyRelation.Complement : DependencyRelation.DirectObject;
                root.Children.Add(objComp);
                unattached.Remove(objComp);
            }
        }

        private void AttachOrphans(SyntaxNode root, List<SyntaxNode> unattached)
        {
            foreach (var orphan in unattached)
            {
                orphan.Relation = DependencyRelation.Unknown;
                root.Children.Add(orphan);
            }
        }
    }
}