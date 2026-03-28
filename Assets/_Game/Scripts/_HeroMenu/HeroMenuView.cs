using DG.Tweening;
using Gameplay;
using R3;
using TMPro;
using UI;
using UnityEngine;
using Utils;

namespace HeroMenu
{
    public class HeroMenuView : FullscreenUI
    {
        [SerializeField] private Transform _heroContainer;

        [Space]

        [SerializeField] private TMP_Text _heroNameView;
        [SerializeField] private TMP_Text _heroDtailsView;
        [SerializeField] private TMP_Text _priceView;

        [Space]

        [SerializeField] private Transform _lockView;
        [SerializeField] private Transform _selectHeroButtonView;
        [SerializeField] private Transform _buyHeroButtonView;
        [SerializeField] private Transform _alreadySelectedView;

        private Subject<int> _switchHeroButtonPressedSignalSubj = new();
        private Subject<Unit> _selectHeroButtonPressedSignalSubj = new();
        private Subject<Unit> _buyHeroButtonPressedSignalSubj = new();
        private Subject<Unit> _exitButtonPressedSignalSubj = new();

        public Observable<int> SwitchHeroButtonPressedSignal => _switchHeroButtonPressedSignalSubj;
        public Observable<Unit> SelectHeroButtonPressedSignal => _selectHeroButtonPressedSignalSubj;
        public Observable<Unit> BuyhHeroButtonPressedSignal => _buyHeroButtonPressedSignalSubj;
        public Observable<Unit> ExitButtonPressedSignal => _exitButtonPressedSignalSubj;

        public void PressSwitchHeroButton(int step) => _switchHeroButtonPressedSignalSubj.OnNext(step);
        public void PressSelectHeroButton() => _selectHeroButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressBuyHeroButton() => _buyHeroButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressExitButton() => _exitButtonPressedSignalSubj.OnNext(Unit.Default);

        public void AttachHero(Hero hero)
        {
            ClearHeroContainer();

            hero.transform.SetParent(_heroContainer, false);
            hero.transform.localPosition = Vector2.zero;
            hero.transform.localScale = Vector2.one;

            PlayHeroAppearanceAnimation(hero);
        }

        public void UpdateHeroName(string name) => _heroNameView.text = name;
        public void UpdateHeroDetails(string description, int health, int armor) => 
            _heroDtailsView.text = description.InsertValues(health, armor);

        public void UpdateLock(bool isActive)
        {
            _lockView.gameObject.SetActive(isActive);
            _lockView.DOKill(true);
            _lockView.DOPunchPosition(new Vector2(5f, 0f), 0.5f).SetEase(Ease.OutQuad);
        }

        public void UpdateSelectHeroButton(bool isActive)
        {
            SetActiveView(_selectHeroButtonView, isActive);
        }

        public void UpdateBuyHeroButton(bool isActive, int price)
        {
            SetActiveView(_buyHeroButtonView, isActive);
            _priceView.text = price.ToString();
        }

        public void UpdateAlreadySelected(bool isActive)
        {
            SetActiveView(_alreadySelectedView, isActive);
        }

        private void ClearHeroContainer()
        {
            foreach (Transform child in _heroContainer)
                Destroy(child.gameObject);
        }

        private void PlayHeroAppearanceAnimation(Hero hero)
        {
            hero.transform.localScale = new Vector2(0.85f, 0.85f);
            hero.transform.DOScale(Vector2.one, 0.15f).SetEase(Ease.OutBack);
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