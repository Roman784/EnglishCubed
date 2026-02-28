using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public abstract class AstNode
    {
    }

    public class SentenceNode : AstNode
    {
        public SubjectNode Subject;
        public PredicateNode Predicate;

        public bool IsQuestion;
        public WordData Auxiliary;

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("SentenceNode");
            result.AppendLine("{");

            result.AppendLine($"\tIsQuestion: {IsQuestion}");

            if (Auxiliary != null)
                result.AppendLine($"\tAuxiliary: \"{Auxiliary.Text}\"");

            result.AppendLine("\tSubject:");
            if (Subject != null)
            {
                var subjectStr = Subject.ToString().Replace("\n", "\n\t\t");
                result.AppendLine($"\t\t{subjectStr.Trim()}");
            }
            else
                result.AppendLine("\t\tnull");

            result.AppendLine("\tPredicate:");
            if (Predicate != null)
            {
                var predicateStr = Predicate.ToString().Replace("\n", "\n\t\t");
                result.AppendLine($"\t\t{predicateStr.Trim()}");
            }
            else
                result.AppendLine("\t\tnull");

            result.Append("}");
            return result.ToString();
        }
    }

    public class SubjectNode : AstNode
    {
        public List<WordData> Words = new();

        // Returns the "main" word (noun or pronoun).
        public WordData GetHead()
        {
            return Words.FirstOrDefault(w =>
                w.PartOfSpeech == PartOfSpeech.Noun ||
                w.PartOfSpeech == PartOfSpeech.Pronoun);
        }

        public bool HasArticle(out WordData article)
        {
            article = Words.FirstOrDefault(w => w.PartOfSpeech == PartOfSpeech.Article);
            return article != null;
        }

        public List<WordData> GetAdjectives()
        {
            return Words
                .Where(w => w.PartOfSpeech == PartOfSpeech.Adjective)
                .ToList();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("SubjectNode");
            result.AppendLine("{");
            result.AppendLine("\tWords:");
            result.AppendLine("\t[");

            for (int i = 0; i < Words.Count; i++)
            {
                var word = Words[i];
                var isLast = i == Words.Count - 1;

                result.AppendLine($"\t\t{i}: {word.PartOfSpeech} \"{word.Text}\"{(isLast ? "" : ",")}");
            }

            result.AppendLine("\t]");

            if (HasArticle(out var article))
                result.AppendLine($"\tArticle: \"{article.Text}\"");

            var adjectives = GetAdjectives();
            if (adjectives.Any())
                result.AppendLine($"\tAdjectives: {adjectives.Count}");

            var head = GetHead();
            if (head != null)
                result.AppendLine($"\tHead: \"{head.Text}\" ({head.PartOfSpeech})");

            result.Append("}");
            return result.ToString();
        }
    }

    public class PredicateNode : AstNode
    {
        public WordData Verb;
        public List<WordData> Objects = new();

        // For linking verbs. Example: tired.
        public WordData Complement;

        public bool HasObject()
        {
            return Objects != null && Objects.Count > 0;
        }

        public bool HasComplement()
        {
            return Complement != null;
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("PredicateNode");
            result.AppendLine("{");

            result.Append("\tVerb: ");
            if (Verb != null)
                result.AppendLine($"\"{Verb.Text}\" [{Verb.VerbAttributes?.VerbForm ?? VerbForm.None}]");
            else
                result.AppendLine("null");

            if (HasComplement())
            {
                result.Append("\tComplement: ");
                result.AppendLine($"\"{Complement.Text}\" ({Complement.PartOfSpeech})");
            }

            if (HasObject())
            {
                result.AppendLine("\tObjects:");
                result.AppendLine("\t[");
                for (int i = 0; i < Objects.Count; i++)
                {
                    var obj = Objects[i];
                    var isLast = i == Objects.Count - 1;
                    result.AppendLine($"\t\t{i}: {obj.PartOfSpeech} \"{obj.Text}\"{(isLast ? "" : ",")}");
                }
                result.AppendLine("\t]");
            }
            else
                result.AppendLine("\tObjects: []");

            result.Append("}");
            return result.ToString();
        }
    }
}