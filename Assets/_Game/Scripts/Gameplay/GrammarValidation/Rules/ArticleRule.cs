using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrammarValidation
{
    public class ArticleRule : IGrammarRule
    {
        public ValidationResult Validate(SentenceNode sentence)
        {
            var res1 = Validate(sentence.Subject.Words);
            var res2 = Validate(sentence.Predicate.Objects);

            if (!res1.IsValid)
                return res1;
            if (!res2.IsValid)
                return res2;

            return ValidationResult.Success();
        }

        private ValidationResult Validate(List<WordData> words)
        {
            var pronoun = words.FirstOrDefault(w => w.PartOfSpeech == PartOfSpeech.Pronoun);
            var noun = words.FirstOrDefault(w => w.PartOfSpeech == PartOfSpeech.Noun);
            var article = words.FirstOrDefault(w => w.PartOfSpeech == PartOfSpeech.Article);
            var hasArticle = article != null;

            if (noun != null)
            {
                var number = noun.NounAttributes.Number;
                var isCountable = noun.NounAttributes.IsCountable;

                if (!hasArticle)
                {
                    if (number == Number.Singular && isCountable)
                        return ValidationResult.Fail("Singular countable noun must have an article!");
                    return ValidationResult.Success();
                }

                if (!isCountable && article.ArticleAttributes.Type != ArticleType.Definite)
                    return ValidationResult.Fail("Uncountable nouns can only use definite article 'the'!");

                if (number == Number.Singular)
                {
                    if (article.ArticleAttributes.Type == ArticleType.Indefinite)
                    {
                        var articleValidation = ValidateIndefiniteArticle(article, noun);
                        if (!articleValidation.IsValid)
                            return articleValidation;
                    }
                }

                if (number == Number.Plural && article.ArticleAttributes.Type == ArticleType.Indefinite)
                    return ValidationResult.Fail("Indefinite article 'a/an' cannot be used with plural nouns!");
            }
            else if (noun == null && hasArticle)
                return ValidationResult.Fail("Article cannot exist without a noun!");
            else if (pronoun != null && hasArticle)
                return ValidationResult.Fail("Article cannot be used before a pronoun!");

            return ValidationResult.Success();
        }

        private ValidationResult ValidateIndefiniteArticle(WordData article, WordData noun)
        {
            var articleText = article.Text.ToLower();
            var nounText = noun.Text;

            if (articleText == "a" && StartsWithVowelSound(nounText))
                return ValidationResult.Fail($"Use 'an' instead of 'a' before '{nounText}' (starts with vowel sound)!");
            else if (articleText == "an" && !StartsWithVowelSound(nounText))
                return ValidationResult.Fail($"Use 'a' instead of 'an' before '{nounText}' (starts with consonant sound)!");
            return ValidationResult.Success();
        }

        private bool StartsWithVowelSound(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;

            var firstLetter = word[0].ToString().ToLower();
            var firstTwoLetters = word.Length > 1 ? word.Substring(0, 2).ToLower() : "";

            return "aeiou".Contains(firstLetter);
        }
    }
}