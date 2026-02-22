using UnityEngine;

namespace GrammarValidation
{
    public class ValencyPattern
    {
        public SentenceRole[] Pattern;

        public ValencyPattern(params SentenceRole[] roles)
        {
            Pattern = roles;
        }
    }
}