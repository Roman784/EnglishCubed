using UnityEngine;

namespace GrammarValidation
{
    public class PresentSimpleVerbAgreementRule : IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            if (sentence.IsQuestion)
                return ValidationResult.Success();

            var subject = sentence.Subject.GetHead();
            var verb = sentence.Predicate.Verb;
            var verbAttributes = verb.VerbAttributes;

            if (verbAttributes.Tense != Tense.Present || verbAttributes.IsLinkingVerb || verbAttributes.IsModal)
                return ValidationResult.Success();

            var isThirdPersonSingular = false;

            if (subject.PartOfSpeech == PartOfSpeech.Pronoun)
            {
                isThirdPersonSingular =
                    subject.PronounAttributes.Person == Person.Third &&
                    subject.PronounAttributes.Number == Number.Singular;
            }
            else if (subject.PartOfSpeech == PartOfSpeech.Noun)
            {
                isThirdPersonSingular =
                    subject.NounAttributes.Number == Number.Singular;
            }
            else
                return ValidationResult.Fail("Sentence must have a subject (noun or pronoun).");

            if (isThirdPersonSingular)
            {
                if (verbAttributes.VerbForm != VerbForm.ThirdPersonS)
                    return ValidationResult.Fail($"Verb must have -s in third person singular. Subject: {subject.Text}, Verb: {verb.Text}");
            }
            else
            {
                if (verbAttributes.VerbForm == VerbForm.ThirdPersonS)
                    return ValidationResult.Fail($"Verb should not have -s with this subject. Subject: {subject.Text}, Verb: {verb.Text}");
            }

            return ValidationResult.Success();
        }
    }
}