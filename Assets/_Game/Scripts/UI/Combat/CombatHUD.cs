using R3;
using UnityEngine;

namespace UI
{
    public class CombatHUD : FullscreenUI
    {
        [SerializeField] private Transform _deckButtonPoint;

        private Subject<Unit> _attackButtonPressedSignalSubj = new();
        private Subject<Unit> _deckButtonPressedSignalSubj = new();

        public Observable<Unit> AttackButtonPressedSignal => _attackButtonPressedSignalSubj;
        public Observable<Unit> DeckButtonPressedSignal => _deckButtonPressedSignalSubj;

        public Vector2 DeckButtonPosition => _deckButtonPoint.position;

        public void PressAttackButton()
        {
            _attackButtonPressedSignalSubj.OnNext(Unit.Default);
        }

        public void PressDeckButton()
        {
            _deckButtonPressedSignalSubj.OnNext(Unit.Default);
        }
    }
}