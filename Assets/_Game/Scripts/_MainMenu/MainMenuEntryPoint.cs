using GameRoot;
using System.Collections;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuEntryPoint : SceneEntryPoint<MainMenuEnterParams>
    {
        protected override IEnumerator Run(MainMenuEnterParams enterParams)
        {
            var isLoaded = false;

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}