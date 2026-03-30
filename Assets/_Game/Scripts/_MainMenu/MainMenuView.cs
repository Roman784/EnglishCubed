using R3;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _continueButtonView;

        private Subject<Unit> _startButtonPressedSignalSubj = new();
        private Subject<Unit> _continueButtonPressedSignalSubj = new();
        private Subject<Unit> _abilitiesButtonPressedSignalSubj = new();
        private Subject<Unit> _heroesButtonPressedSignalSubj = new();

        public Observable<Unit> StartButtonPressedSignal => _startButtonPressedSignalSubj;
        public Observable<Unit> ContinueButtonPressedSignal => _continueButtonPressedSignalSubj;
        public Observable<Unit> AbilitiesButtonPressedSignal => _abilitiesButtonPressedSignalSubj;
        public Observable<Unit> HeroesButtonPressedSignal => _heroesButtonPressedSignalSubj;

        public void PressStartButton() => _startButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressContinueButton() => _continueButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressAbilitiesButton() => _abilitiesButtonPressedSignalSubj.OnNext(Unit.Default);
        public void PressHeroesButton() => _heroesButtonPressedSignalSubj.OnNext(Unit.Default);

        public void SetActiveContinueButton(bool isActive)
        {
            _continueButtonView.interactable = isActive;
            _continueButtonView.blocksRaycasts = isActive;
            _continueButtonView.alpha = isActive ? 1f : 0.5f;
        }
    }
}