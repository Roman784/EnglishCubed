using GameRoot;
using System.Collections;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuEntryPoint : SceneEntryPoint<MainMenuEnterParams>
    {
        [SerializeField] private MainMenuView _view;

        protected override IEnumerator Run(MainMenuEnterParams enterParams)
        {
            var isLoaded = false;

            var model = new MainMenuModel();
            var presenter = new MainMenuPresenter(_view, model);

            G.AudioProvider.PlayMusic(R.Audio.MainMenu);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);

            G.SDK.GameReady();
        }
    }
}