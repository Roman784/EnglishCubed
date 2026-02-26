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

        public bool HasArticle()
        {
            return Words.Any(w => w.PartOfSpeech == PartOfSpeech.Article);
        }

        public List<WordData> GetAdjectives()
        {
            return Words
                .Where(w => w.PartOfSpeech == PartOfSpeech.Adjective)
                .ToList();
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
    }

}