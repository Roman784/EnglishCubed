using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using R3;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsLayout _handWordUnitsLayout;
        [SerializeField] private FieldWordUnitsLayout _fieldWordUnitsLayout;
        [SerializeField] private CombatHUD _mainHUD;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsLayout, _fieldWordUnitsLayout);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsLayout.SetWordUnits(wordUnits.Select(w => w.Transform));

            _mainHUD.AttackButtonPressedSignal.Subscribe(_ => { });

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}