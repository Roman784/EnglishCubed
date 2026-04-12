using GameProducer;
using GameRoot;
using HeroMenu;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapEntryPoint : SceneEntryPoint<EncountersMapEnterParams>
    {
        [SerializeField] private EncountersMapView _view;

        protected override IEnumerator Run(EncountersMapEnterParams enterParams)
        {
            var isLoaded = false;

            Random.InitState(G.GameSessionProvider.SessionData.Seed);

            var passedEncounters = G.GameSessionProvider.SessionData.PassedEncounters;
            var mapGenerator = new EncountersMapGenerator();

            var model = new EncountersMapModel(
                passedEncounters: passedEncounters,
                mapGenerator: mapGenerator,
                mapSize: new Vector2Int(7, 7),
                spacingBetweenEncounterButtons: 384);
            var presenter = new EncountersMapPresenter(_view, model);

            presenter.CreateMap();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}