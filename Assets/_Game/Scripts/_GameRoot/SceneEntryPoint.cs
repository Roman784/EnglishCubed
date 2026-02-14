using System.Collections;
using TestRoom;
using UnityEngine;

namespace GameRoot
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        public abstract IEnumerator Run<T>(T enterParams) where T : SceneEnterParams;
    }

    public abstract class SceneEntryPoint<TEnterParams> : SceneEntryPoint where TEnterParams : SceneEnterParams
    {
        public override IEnumerator Run<T>(T enterParams)
        {
            if (enterParams.TryCast<TEnterParams>(out var specificParams))
                yield return Run(specificParams);
            else
                Debug.LogError($"Failed to convert {typeof(T)} to {typeof(TEnterParams)}!");
        }

        protected abstract IEnumerator Run(TEnterParams enterParams);
    }
}