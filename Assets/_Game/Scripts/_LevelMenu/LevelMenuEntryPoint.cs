using Configs;
using GameRoot;
using System.Collections;
using UnityEngine;

namespace LevelMenu
{
    public class LevelMenuEntryPoint : SceneEntryPoint<LevelMenuEnterParams>
    {
        [SerializeField] private LevelMenuView _view;

        protected override IEnumerator Run(LevelMenuEnterParams enterParams)
        {
            var isLoaded = false;

            var model = new LevelMenuModel();
            var presenter = new LevelMenuPresenter(_view, model);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}