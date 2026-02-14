using Audio;
using GameRoot;
using GameState;
using System.Collections;
using UI;
using UnityEngine;

namespace TestRoom
{
    public class TestRoomEntryPoint : SceneEntryPoint<TestRoomEnterParams>
    {
        // Sequential scene initialization.
        protected override IEnumerator Run(TestRoomEnterParams enterParams)
        {
            var isLoaded = false;

            Debug.Log("hi");

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}