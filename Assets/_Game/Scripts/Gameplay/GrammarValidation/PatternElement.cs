using UnityEngine;

namespace GrammarValidation
{
    public class PatternElement
    {
        public PartOfSpeech? PartOfSpeech;
        public bool RequireBe;
        public bool RequireModal;
        public bool RequireNegative;
        public bool Optional;

        public GrammarRole role = GrammarRole.None;

        public bool Match(WordData word)
        {
            if (PartOfSpeech.HasValue && word.PartOfSpeech != PartOfSpeech.Value)
                return false;

            /*if (RequireBe && !word.IsBeVerb)
                return false;

            if (RequireModal && !word.IsModal)
                return false;

            if (RequireNegative && !word.IsNegative)
                return false;*/

            return true;
        }
    }
}