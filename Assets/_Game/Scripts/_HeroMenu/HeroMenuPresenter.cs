using UnityEngine;
using UnityEngine.InputSystem;
using R3;
using GameRoot;
using System.Linq;
using Gameplay;
using Configs;

namespace HeroMenu
{
    public class HeroMenuPresenter
    {
        private HeroMenuView _view;
        private HeroMenuModel _model;

        public HeroMenuPresenter(HeroMenuView view, HeroMenuModel model)
        {
            _view = view;
            _model = model;
            
            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {
            _view.SwitchHeroButtonPressedSignal
                .Subscribe(step => SwitchHero(step));

            _view.SelectHeroButtonPressedSignal
                .Subscribe(_ => SelectCurrentHero());

            _view.BuyhHeroButtonPressedSignal
                .Subscribe(_ => BuyCurrentHero());

            _view.ExitButtonPressedSignal
                .Subscribe(_ => ExitFromMenu());
        }

        public void ShowCurrentHero()
        {
            var heroConfigs = _model.GetCurrentHeroConfigs();

            if (!_model.IsCurrentHeroAlreadyDisplayed())
                CreateHeroView(heroConfigs);

            var isUnlocked = _model.IsCurrentHeroUnlocked();
            var isSelected = _model.IsCurrentHeroSelected();

            _view.UpdateLock(!isUnlocked);
            _view.UpdateSelectHeroButton(!isSelected && isUnlocked);
            _view.UpdateBuyHeroButton(!isUnlocked, heroConfigs.Price);
            _view.UpdateAlreadySelected(isSelected);
        }

        private void CreateHeroView(HeroConfigs configs)
        {
            var createdHero = Object.Instantiate(configs.Prefab);
            _view.AttachHero(createdHero);
            _view.UpdateHeroName(configs.NameDescription);
            _view.UpdateHeroDetails(
                configs.DetailsDescription, configs.Health, configs.Armor);

            _model.SetDisplayedHero(configs.Name);
        }

        private void SwitchHero(int step)
        {
            _model.SetCurrentHeroIndex(step);
            ShowCurrentHero();
        }

        private void SelectCurrentHero()
        {
            if (!_model.IsCurrentHeroUnlocked()) return;

            // TODO: Select hero in game state.

            _model.SelectCurrentHero();
            ShowCurrentHero();
        }

        private void BuyCurrentHero()
        {
            if (_model.IsCurrentHeroUnlocked()) return;

            var heroConfigs = _model.GetCurrentHeroConfigs();
            var price = heroConfigs.Price;

            // TODO: Implement coins and buying logic
            /*if (Coins < price) return;
                Coins -= price;*/
            // TODO: Save unlocked hero to game state.

            _model.UnlockCurrentHero();
            ShowCurrentHero();
        }

        private void ExitFromMenu()
        {
            G.SceneProvider.OpenMainMenu();
        }
    }
}