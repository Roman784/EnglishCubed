using Audio;
using Configs;
using Gameplay;
using GameRoot;
using GameState;
using System.Collections;
using UI;
using UnityEngine;
using R3;
using System.Collections.Generic;
using GrammarValidation;

namespace TestRoom
{
    public class TestRoomEntryPoint : SceneEntryPoint<TestRoomEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;

        // Sequential scene initialization.
        protected override IEnumerator Run(TestRoomEnterParams enterParams)
        {
            var isLoaded = false;

            G.HandWordUnitsGroup = _handWordUnitsGroup;
            G.FieldWordUnitsGroup = _fieldWordUnitsGroup;

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsGroup.SetWordUnits(wordUnits);

            var grammarValidator = new PatternGrammarValidator(DictionaryData.Words);

            Debug.Log("=== AGREEMENT ===");
            CheckSentence(grammarValidator, "i am wise", true);
            CheckSentence(grammarValidator, "he is wise", true);
            CheckSentence(grammarValidator, "she is wise", true);
            CheckSentence(grammarValidator, "we are wise", true);
            CheckSentence(grammarValidator, "they are wise", true);
            CheckSentence(grammarValidator, "i are wise", false);
            CheckSentence(grammarValidator, "he am wise", false);
            CheckSentence(grammarValidator, "she are wise", false);
            CheckSentence(grammarValidator, "we is wise", false);
            CheckSentence(grammarValidator, "they is wise", false);

            

            /*var sen1 = "he is good";
            var sen2 = "i am not stupid";
            var sen3 = "we will be beautiful";
            var sen4 = "they were not wise";
            var sen5 = "where were they?";
            var sen6 = "were they here?";
            var sen7 = "did they see you?";

            var sen12 = "i is good";
            var sen22 = "am i not stupid?";
            var sen32 = "we will beautiful be";
            var sen42 = "not they were wise";

            Debug.Log($"{sen1} - {grammarValidator.Validate(sen1)}");
            Debug.Log($"{sen2} - {grammarValidator.Validate(sen2)}");
            Debug.Log($"{sen3} - {grammarValidator.Validate(sen3)}");
            Debug.Log($"{sen4} - {grammarValidator.Validate(sen4)}");
            Debug.Log($"{sen4} - {grammarValidator.Validate(sen4)}");
            Debug.Log($"{sen5} - {grammarValidator.Validate(sen5)}");
            Debug.Log($"{sen6} - {grammarValidator.Validate(sen6)}");
            Debug.Log($"{sen7} - {grammarValidator.Validate(sen7)}");

            Debug.Log($"{sen12} - {grammarValidator.Validate(sen12)}");
            Debug.Log($"{sen22} - {grammarValidator.Validate(sen22)}");
            Debug.Log($"{sen32} - {grammarValidator.Validate(sen32)}");
            Debug.Log($"{sen42} - {grammarValidator.Validate(sen42)}");*/

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }

        private void CheckSentence(PatternGrammarValidator validator, string sentence, bool expectedRes)
        {
            if (validator.Validate(sentence) != expectedRes)
                Debug.Log($"{validator.Validate(sentence) == expectedRes} - {sentence}");
        }
    }
}