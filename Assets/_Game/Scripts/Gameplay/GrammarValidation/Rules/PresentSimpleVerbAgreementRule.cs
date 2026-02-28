using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace GrammarValidation
{
    public class PresentSimpleVerbAgreementRule: IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            if (sentence.IsQuestion)
                return ValidationResult.Success();

            var subject = sentence.Subject.GetHead();
            var verb = sentence.Predicate.Verb.VerbAttributes;

            if (verb.Tense != Tense.Present || verb.IsLinkingVerb || verb.IsModal)
                return ValidationResult.Success();

            if (subject.PartOfSpeech == PartOfSpeech.Pronoun)
            {
                var pronoun = subject.PronounAttributes;

                if (verb.Person == Person.Third && !(pronoun.Person == Person.Third && pronoun.Number == Number.Singular))
                    return ValidationResult.Fail($"Verb person third requires third singular pronoun.");
                else if (verb.Person == Person.First && pronoun.Person == Person.Third && pronoun.Number == Number.Singular)
                    return ValidationResult.Fail($"Verb person first requires not third singular pronoun.");
            }
            else if (subject.PartOfSpeech == PartOfSpeech.Noun)
            {
                var noun = subject.NounAttributes;

                if (verb.Person == Person.Third && noun.Number != Number.Singular) // like.
                    return ValidationResult.Fail($"Verb person third requires singular noun.");
                if (verb.Person == Person.First && noun.Number != Number.Plural) // likes.
                    return ValidationResult.Fail($"Verb person first requires plural noun.");
            }
            else
                return ValidationResult.Fail("Sentence must have a subject (noun or pronoun).");

            return ValidationResult.Success();
        }
    }
}