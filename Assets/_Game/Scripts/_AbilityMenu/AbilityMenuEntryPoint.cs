using GameRoot;
using System.Collections;
using UnityEngine;

namespace AbilityMenu
{
    public class AbilityMenuEntryPoint : SceneEntryPoint<AbilityMenuEnterParams>
    {
        protected override IEnumerator Run(AbilityMenuEnterParams enterParams)
        {
            var isLoaded = false;

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}