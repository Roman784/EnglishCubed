using Currency;
using Gameplay;
using GameRoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeroMenu
{
    public class HeroMenuEntryPoint : SceneEntryPoint<HeroMenuEnterParams>
    {
        [SerializeField] private HeroMenuView _view;

        protected override IEnumerator Run(HeroMenuEnterParams enterParams)
        {
            var isLoaded = false;

            var unlockedHeroes = new List<CreatureName>() // TODO: From game state.
            { 
                CreatureName.Knight,
                CreatureName.Cactus
            };

            _view.BindWalletView(G.Wallet);

            var model = new HeroMenuModel(
                heroConfigs: G.Configs.HeroesConfigs.AllHeroesConfigs,
                unlockedHeroes: unlockedHeroes,
                currentHeroName: CreatureName.Knight, // TODO: From game state.
                selectedHero: CreatureName.Knight); // TODO: From game state.
            var presenter = new HeroMenuPresenter(_view, model);

            presenter.ShowCurrentHero();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}