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

            var heroesConfigs = G.Configs.HeroesConfigs.AllHeroesConfigs;
            var unlockedHeroes = G.Repository.MetaProgression.GetUnlockedHeroes();
            var selectedHero = G.Repository.MetaProgression.GetSelectedHero();

            _view.BindWalletView(G.Wallet);

            var model = new HeroMenuModel(
                heroesConfigs: heroesConfigs,
                unlockedHeroes: unlockedHeroes,
                selectedHero: selectedHero);
            var presenter = new HeroMenuPresenter(_view, model);

            yield return null;

            presenter.ShowCurrentHero();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}