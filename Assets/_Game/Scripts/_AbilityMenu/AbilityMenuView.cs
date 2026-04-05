using Currency;
using DG.Tweening;
using R3;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace AbilityMenu
{
    public class AbilityMenuView : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;

        [Space]

        [SerializeField] private Transform _abilityButtonsContainer;

        [Space]

        [SerializeField] private Image _abilityIconView;
        [SerializeField] private TMP_Text _abilityNameView;
        [SerializeField] private TMP_Text _abilityDescriptionView;
        [SerializeField] private TMP_Text _abilityPriceView;

        [Space]

        [SerializeField] private Transform _buyAbilityButtonView;
        [SerializeField] private Transform _alreadyBoughtView;

        [Space]

        [SerializeField] private AbilitySelectionButton abilityButtonPrefab;

        private Subject<Unit> _buyAbilityButtonPressedSignalSubj = new();
        private Subject<Unit> _exitButtonPressedSignalSubj = new();

        public Observable<Unit> BuyAbilityButtonPressedSignal => _buyAbilityButtonPressedSignalSubj;
        public Observable<Unit> ExitButtonPressedSignal => _exitButtonPressedSignalSubj;

        public void PressBuyAbilityButton() => _buyAbilityButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressExitButton() => _exitButtonPressedSignalSubj.OnNext(Unit.Default);

        public void BindWalletView(Wallet wallet) => _walletView.Bind(wallet);

        private void Start()
        {
            ClearAbilityButtonsContainer();
        }

        public AbilitySelectionButton CreateAbilityButton()
        {
            var button = Instantiate(abilityButtonPrefab);
            AttachAbiltyButton(button);
            return button;
        }

        public void HideAbilityInfo()
        {
            _buyAbilityButtonView.gameObject.SetActive(false);
            _alreadyBoughtView.gameObject.SetActive(false);
            _abilityIconView.gameObject.SetActive(false);
            _abilityNameView.gameObject.SetActive(false);
            _abilityDescriptionView.gameObject.SetActive(false);
        }

        public void ShowAbilityInfo()
        {
            _abilityIconView.gameObject.SetActive(true);
            _abilityNameView.gameObject.SetActive(true);
            _abilityDescriptionView.gameObject.SetActive(true);
        }

        public void UpdateAbilityIcon(Sprite icon)
        {
            _abilityIconView.sprite = icon;

            _abilityIconView.DOKill(true);
            _abilityIconView.transform.DOPunchScale(Vector2.one * 0.05f, 0.35f, 6).SetEase(Ease.OutQuad);
        }

        public void UpdateAbilityName(string name)
        {
            _abilityNameView.text = name;
        }

        public void UpdateAbilityDescription(string description)
        {
            _abilityDescriptionView.text = description;
        }

        public void UpdateBuyAbilityButton(bool isActive, int price)
        {
            SetActiveView(_buyAbilityButtonView, isActive);
            _abilityPriceView.text = price.ToCoinsFormat();
        }

        public void UpdateAlreadyBought(bool isActive)
        {
            SetActiveView(_alreadyBoughtView, isActive);
        }

        private void ClearAbilityButtonsContainer()
        {
            foreach (Transform child in _abilityButtonsContainer)
                Destroy(child.gameObject);
        }

        private void AttachAbiltyButton(AbilitySelectionButton button)
        {
            button.transform.SetParent(_abilityButtonsContainer, false);
            button.transform.localPosition = Vector2.zero;
            button.transform.localScale = Vector2.one;

            PlayAbilityButtonAppearanceAnimation(button);
        }

        private void PlayAbilityButtonAppearanceAnimation(AbilitySelectionButton button)
        {
            button.transform.localScale = new Vector2(0.85f, 0.85f);
            button.transform.DOScale(Vector2.one, 0.15f).SetEase(Ease.OutBack);
        }

        private void SetActiveView(Transform view, bool isActive)
        {
            if (view.gameObject.activeSelf == isActive) return;
            view.gameObject.SetActive(isActive);
            view.DOKill(true);
            view.DOPunchScale(Vector2.one * 0.05f, 0.35f, 6).SetEase(Ease.OutQuad);
        }
    }
}