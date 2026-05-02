using Abilities;
using Configs;
using GameRoot;
using R3;
using System.Collections.Generic;
using UI;

namespace AbilityMenu
{
    public class AbilityMenuPresenter
    {
        private AbilityMenuView _view;
        private AbilityMenuModel _model;

        public AbilityMenuPresenter(AbilityMenuView view, AbilityMenuModel model)
        {
            _view = view;
            _model = model;

            SetupSubscriptions();
            CreateAbilitySelectionButtons();

            _view.HideAbilityInfo();
        }

        private void SetupSubscriptions()
        {
            _view.BuyAbilityButtonPressedSignal
                .Subscribe(_ => BuySelectedAbility());

            _view.ExitButtonPressedSignal
                .Subscribe(_ => ExitFromMenu());
        }

        private void CreateAbilitySelectionButtons()
        {
            var createdButtonsMap = new Dictionary<AbilityName, AbilitySelectionButton>();

            foreach (var abilityConfigs in _model.AllAbilitiesConfigs)
            {
                var button = _view.CreateAbilityButton();
                button.SetIcon(abilityConfigs.Icon);
                button.SetIsLocked(!_model.IsAbilityUnlocked(abilityConfigs.Name));
                button.SelectedSignal
                    .Subscribe(isLocked => SelectAbility(abilityConfigs, isLocked));

                createdButtonsMap[abilityConfigs.Name] = button;
            }

            _model.SetAbilitySelectionButtonsMap(createdButtonsMap);
        }

        private void SelectAbility(AbilityConfigs configs, bool isLocked)
        {
            _model.SetSelectedAbility(configs);

            _view.ShowAbilityInfo();

            _view.UpdateAbilityIcon(configs.Icon);
            _view.UpdateAbilityName(configs.Title);
            _view.UpdateAbilityDescription(configs.Description);

            _view.UpdateBuyAbilityButton(isLocked, configs.Price);
            _view.UpdateAlreadyBought(!isLocked);
        }

        private void BuySelectedAbility()
        {
            var selectedAbility = _model.SelectedAbility;
            if (selectedAbility == null || _model.IsAbilityUnlocked(selectedAbility.Name)) return;

            var price = selectedAbility.Price;
            if (!G.Wallet.TrySpendCoins(price))
            {
                G.UIRoot.ShowMessage("Сначала накопи достаточное количество монет"); // Loc.
                return;
            }

            _model.Repository.UnlockAbility(selectedAbility.Name);
            _model.UnlockSelectedAbility();

            _model.AbilitySelectionButtonsMap[selectedAbility.Name].SetIsLocked(false);
            SelectAbility(selectedAbility, isLocked: false);
        }

        private void ExitFromMenu()
        {
            G.SceneProvider.OpenMainMenu();
        }
    }
}