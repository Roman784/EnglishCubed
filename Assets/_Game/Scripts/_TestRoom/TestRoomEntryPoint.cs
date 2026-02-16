using Audio;
using Configs;
using Gameplay;
using GameRoot;
using GameState;
using System.Collections;
using UI;
using UnityEngine;
using R3;

namespace TestRoom
{
    public class TestRoomEntryPoint : SceneEntryPoint<TestRoomEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private WordUnitsLayoutGroup _handWordUnitsGroup;
        [SerializeField] private WordUnitsLayoutGroup _fieldWordUnitsGroup;

        // Sequential scene initialization.
        protected override IEnumerator Run(TestRoomEnterParams enterParams)
        {
            var isLoaded = false;

            G.HandWordUnitsGroup = _handWordUnitsGroup;
            G.FieldWordUnitsGroup = _fieldWordUnitsGroup;

            var i = 0;
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                _handWordUnitsGroup.Add(newWordUnit);
                i++;
            }

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}