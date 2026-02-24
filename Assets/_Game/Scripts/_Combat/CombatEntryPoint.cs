using GameRoot;
using System.Collections;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;



            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}