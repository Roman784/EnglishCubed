using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class SyntaxProperties
    {
        public VerbType? VerbType;
        public string RequiredPreposition; // Exaple: depend on, look at.

        public List<ValencyPattern> AllowedPatterns = new();
    }
}