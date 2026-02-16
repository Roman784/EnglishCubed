using Audio;
using Configs;
using Gameplay;
using GameRoot;
using GameState;
using System.Collections;
using UI;
using UnityEngine;

namespace TestRoom
{
    public class TestRoomEntryPoint : SceneEntryPoint<TestRoomEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private WordUnitsLayoutGroup _wordUnitsLayoutGroup;

        // Sequential scene initialization.
        protected override IEnumerator Run(TestRoomEnterParams enterParams)
        {
            var isLoaded = false;

            var i = 0;
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                _wordUnitsLayoutGroup.Add(newWordUnit);
                i++;
            }

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}