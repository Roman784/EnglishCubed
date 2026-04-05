using GameRoot;
using System.Collections;
using UnityEngine;

namespace AbilityMenu
{
    public class AbilityMenuEntryPoint : SceneEntryPoint<AbilityMenuEnterParams>
    {
        [SerializeField] private AbilityMenuView _view;

        protected override IEnumerator Run(AbilityMenuEnterParams enterParams)
        {
            var isLoaded = false;

            var allAbilitiesConfigs = G.Configs.AbilitiesConfigs.AllAbilities;
            var unlockedAbilities = G.Repository.MetaProgression.GetUnlockedAbilities();

            _view.BindWalletView(G.Wallet);

            var model = new AbilityMenuModel(
                allAbilitiesConfigs: allAbilitiesConfigs,
                unlockedAbilities: unlockedAbilities);
            var presenter = new AbilityMenuPresenter(_view, model);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}