using GameRoot;
using HeroMenu;
using System.Collections;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapEntryPoint : SceneEntryPoint<EncountersMapEnterParams>
    {
        [SerializeField] private EncountersMapView _view;

        protected override IEnumerator Run(EncountersMapEnterParams enterParams)
        {
            var isLoaded = false;

            var model = new EncountersMapModel(
                );
            var presenter = new EncountersMapPresenter(_view, model);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}