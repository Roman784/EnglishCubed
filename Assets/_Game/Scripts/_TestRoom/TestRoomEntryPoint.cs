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

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}