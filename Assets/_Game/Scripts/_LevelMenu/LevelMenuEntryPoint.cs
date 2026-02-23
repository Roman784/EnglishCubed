using GameRoot;
using System.Collections;
using UnityEngine;

namespace LevelMenu
{
    public class LevelMenuEntryPoint : SceneEntryPoint<LevelMenuEnterParams>
    {
        protected override IEnumerator Run(LevelMenuEnterParams enterParams)
        {
            var isLoaded = false;

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}