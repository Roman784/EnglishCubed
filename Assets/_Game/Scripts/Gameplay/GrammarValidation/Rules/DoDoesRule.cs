using UnityEngine;

namespace GrammarValidation
{
    public class DoDoesRule: IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            if (!sentence.IsQuestion)
                return ValidationResult.Success();

            var aux = sentence.Auxiliary;
            var subject = sentence.Subject.GetHead();
            var verb = sentence.Predicate.Verb;

            if (verb.VerbAttributes.Tense != Tense.Present)
                return ValidationResult.Success();

            if (aux.Text != "do" && aux.Text != "does")
                return ValidationResult.Success();

            if (subject.PartOfSpeech == PartOfSpeech.Pronoun)
            {
                var pronoun = subject.PronounAttributes;

                if (aux.Text == "does" && !(pronoun.Person == Person.Third && pronoun.Number == Number.Singular)) // he, she, it -> does
                    return ValidationResult.Fail($"Pronoun '{subject.Text}' does not agree with auxiliary 'does'");
                else if (aux.Text == "do" && pronoun.Person == Person.Third && pronoun.Number == Number.Singular)
                    return ValidationResult.Fail($"Pronoun '{subject.Text}' does not agree with auxiliary 'do'");
            }
            else if (subject.PartOfSpeech == PartOfSpeech.Noun)
            {
                var noun = subject.NounAttributes;

                if (aux.Text == "does" && noun.Number != Number.Singular)
                    return ValidationResult.Fail("'Does' requires singular noun.");
                if (aux.Text == "do" && noun.Number != Number.Plural)
                    return ValidationResult.Fail("'Do' requires plural noun.");
            }
            else
                return ValidationResult.Fail("Sentence must have a subject (noun or pronoun).");

            if (verb.VerbAttributes.VerbForm != VerbForm.Base)
                return ValidationResult.Fail("Verb must be in base form after auxiliary.");

            return ValidationResult.Success();
        }
    }
}