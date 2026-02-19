using System.Collections.Generic;

namespace GrammarValidation
{
    public interface IGrammarValidator
    {
        public bool Validate(string sentence);
    }
}