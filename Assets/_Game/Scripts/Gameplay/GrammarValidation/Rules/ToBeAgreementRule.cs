using UnityEngine;

namespace GrammarValidation
{
    public class ToBeAgreementRule : IGrammarRule 
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            var verb = sentence.Predicate.Verb.VerbAttributes;

            if (!verb.IsLinkingVerb)
                return ValidationResult.Success();

            var subject = sentence.Subject.GetHead();

            if (subject.PartOfSpeech == PartOfSpeech.Pronoun)
            {
                var pronoun = subject.PronounAttributes;

                if (pronoun.Number == Number.Plural && verb.Number != Number.Plural) // we, they -> are.
                    return ValidationResult.Fail($"Pronoun '{subject.Text}' ({pronoun.Number} number) does not agree with verb ({verb.Number} number)");
                
                else if (pronoun.Number != Number.Plural && pronoun.Person != verb.Person) // i -> am. he, she, it -> is. you -> are.
                    return ValidationResult.Fail($"Pronoun '{subject.Text}' ({pronoun.Person} person) does not agree with verb ({verb.Person} person)");
            }
            else if (subject.PartOfSpeech == PartOfSpeech.Noun)
            {
                var noun = subject.NounAttributes;

                if (noun.Number != verb.Number)
                    return ValidationResult.Fail($"Noun '{subject.Text}' ({noun.Number} number) does not agree with verb ({verb.Number} number)");

                if (!noun.IsCountable && !(verb.Number == Number.Singular && verb.Person == Person.Third))
                    return ValidationResult.Fail($"Uncountable noun '{subject.Text}' requires singular verb (is)");
            }

            return ValidationResult.Success();
        }
    }
}