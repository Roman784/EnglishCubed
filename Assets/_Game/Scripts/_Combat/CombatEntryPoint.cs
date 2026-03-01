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
using System;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;
        [SerializeField] private CombatHUD _mainHUD;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            _fieldWordUnitsGroup.SetMaxAvailableWordsCount(5);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsGroup.SetInitialWordUnits(wordUnits);

            _mainHUD.AttackButtonPressedSignal.ThrottleFirst(System.TimeSpan.FromSeconds(0.25f)).Subscribe(_ =>
            {
                var sentence = string.Join(" ", _fieldWordUnitsGroup.AllWordUnits.Select(w => w.GetWordText()));
                var res = grammarValidator.Validate(sentence);
                if (!res.IsValid)
                {
                    G.UIRoot.ShowMessage(G.Configs.GrammarHintsConfigs.GetMessage(res.HintCode));
                }
            });

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}