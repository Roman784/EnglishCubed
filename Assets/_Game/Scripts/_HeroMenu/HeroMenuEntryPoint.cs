using GameRoot;
using System.Collections;
using UnityEngine;

namespace HeroMenu
{
    public class HeroMenuEntryPoint : SceneEntryPoint<HeroMenuEnterParams>
    {
        protected override IEnumerator Run(HeroMenuEnterParams enterParams)
        {
            var isLoaded = false;

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}