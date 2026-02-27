using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsLayout _handWordUnitsLayout;
        [SerializeField] private FieldFlowLayout _fieldWordUnitsLayout;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsLayout, _fieldWordUnitsLayout);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsLayout.SetWordUnits(wordUnits.Select(w => w.Transform));

            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            // PresentSimpleVerbAgreementRule.
            grammarValidator.DebugSentence("i like workers", true);
            grammarValidator.DebugSentence("you like workers", true);
            grammarValidator.DebugSentence("he likes workers", true);
            grammarValidator.DebugSentence("she likes workers", true);
            grammarValidator.DebugSentence("it likes workers", true);
            grammarValidator.DebugSentence("we like workers", true);
            grammarValidator.DebugSentence("they like workers", true);

            grammarValidator.DebugSentence("worker likes workers", true);
            grammarValidator.DebugSentence("workers like workers", true);

            grammarValidator.DebugSentence("he like workers", false);
            grammarValidator.DebugSentence("she like workers", false);
            grammarValidator.DebugSentence("it like workers", false);
            grammarValidator.DebugSentence("worker like workers", false);

            grammarValidator.DebugSentence("i likes workers", false);
            grammarValidator.DebugSentence("you likes workers", false);
            grammarValidator.DebugSentence("we likes workers", false);
            grammarValidator.DebugSentence("they likes workers", false);
            grammarValidator.DebugSentence("workers likes workers", false);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}