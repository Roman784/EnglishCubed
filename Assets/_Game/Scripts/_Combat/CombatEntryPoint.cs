using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsGroup.SetWordUnits(wordUnits);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}