using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class SubjectNumberAgreementRule : IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            var verb = sentence.Predicate.Verb.VerbAttributes;

            if (!verb.IsLinkingVerb)
                return ValidationResult.Success();

            var obj = sentence.Predicate.Objects.FirstOrDefault(
                o => o.PartOfSpeech == PartOfSpeech.Pronoun || o.PartOfSpeech == PartOfSpeech.Noun);

            if (obj == null)
                return ValidationResult.Success();

            var subject = sentence.Subject.GetHead();
            var subjectNumber =
                subject.PartOfSpeech == PartOfSpeech.Pronoun ? subject.PronounAttributes.Number :
                subject.PartOfSpeech == PartOfSpeech.Noun ? subject.NounAttributes.Number : Number.None;

            var objNumber =
                obj.PartOfSpeech == PartOfSpeech.Pronoun ? obj.PronounAttributes.Number :
                obj.PartOfSpeech == PartOfSpeech.Noun ? obj.NounAttributes.Number : Number.None;

            if (subjectNumber != objNumber)
                return ValidationResult.Fail($"Subject '{subject.Text}' ({subjectNumber} number) does not agree with object ({objNumber} number)");

            return ValidationResult.Success();
        }
    }
}