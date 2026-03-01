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
        [SerializeField] private HandFlowLayout _handLayout;
        [SerializeField] private FieldFlowLayout _fieldLayout;
        [SerializeField] private CombatHUD _mainHUD;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            var handWordUnitsGroup = new HandWordUnitsGroup(_handLayout);
            var fieldWordUnitsGroup = new FieldWordUnitsGroup(_fieldLayout);

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(handWordUnitsGroup, fieldWordUnitsGroup);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            handWordUnitsGroup.SetInitialWordUnits(wordUnits);

            _mainHUD.AttackButtonPressedSignal.ThrottleFirst(System.TimeSpan.FromSeconds(0.25f)).Subscribe(_ =>
            {
                Debug.Log($"Hand: {handWordUnitsGroup.AllWordUnits.Count()}\nField: {fieldWordUnitsGroup.AllWordUnits.Count()}");
            });

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}