using Gameplay;
using GameRoot;
using R3;
using TMPro;
using UI;
using UnityEngine;
using Utils;

namespace Combat
{
    public class CombatView : FullscreenUI
    {
        [SerializeField] private TMP_Text _discardPointsView;
        [SerializeField] private TMP_Text _drawPointsView;

        [Space]

        [SerializeField] private TMP_Text _availableWordsOnFieldView;
        [SerializeField] private TMP_Text _handCapacityView;

        [Space]

        [SerializeField] private Transform _deckButtonPoint;
        [SerializeField] private Transform _drawWordUnitsButtonPoint;

        [Space]

        [SerializeField] private Transform _defaultPointsShowingPoint;

        [Space]

        [SerializeField] private StatCellsView _heroHealthStatView;
        [SerializeField] private StatCellsView _heroArmorStatView;
        [SerializeField] private StatBarView _heroExperienceStatView; 

        private bool _isEnabled;

        private Subject<Unit> _attackButtonPressedSignalSubj = new();
        private Subject<Unit> _deckButtonPressedSignalSubj = new();
        private Subject<Unit> _drawButtonPressedSignalSubj = new();
        private Subject<Unit> _discardButtonPressedSignalSubj = new();

        public StatCellsView HeroHealthStatView => _heroHealthStatView;
        public StatCellsView HeroArmorStatView => _heroArmorStatView;
        public StatBarView HeroExperienceStatView => _heroExperienceStatView;

        public Observable<Unit> AttackButtonPressedSignal => _attackButtonPressedSignalSubj;
        public Observable<Unit> DeckButtonPressedSignal => _deckButtonPressedSignalSubj;
        public Observable<Unit> DrawButtonPressedSignal => _drawButtonPressedSignalSubj;
        public Observable<Unit> DiscardButtonPressedSignal => _discardButtonPressedSignalSubj;

        public Vector2 DeckButtonPosition => _deckButtonPoint.position;
        public Vector2 DrawWordUnitsButtonPosition => _drawWordUnitsButtonPoint.position;
        public Vector2 DefaultPointsShowingPosition => _defaultPointsShowingPoint.position;

        public void EnableControls()
        {
            _isEnabled = true;
            G.WordUnitsMovementProvider.Enable();
        }

        public void DisableControls()
        {
            _isEnabled = false;
            G.WordUnitsMovementProvider.Disable();
        }

        public void PressAttackButton() { if (_isEnabled) _attackButtonPressedSignalSubj.OnNext(Unit.Default); }
        public void PressDeckButton() { if (_isEnabled) _deckButtonPressedSignalSubj.OnNext(Unit.Default); }
        public void PressDrawButton() { if (_isEnabled) _drawButtonPressedSignalSubj.OnNext(Unit.Default); }
        public void PressDiscardButton() { if (_isEnabled) _discardButtonPressedSignalSubj.OnNext(Unit.Default); }

        public void ShowMessage(string message) => G.UIRoot.ShowMessage(message);

        public void UpdateDiscardPoints(int points)
        {
            if (points > 0)
                _discardPointsView.text = $"В мешок x{points}";
            else
                _discardPointsView.text = $"В мешок<size=92>{TextIcons.BrokenHeart}</size>";
        }

        public void UpdateDrawPoints(int points)
        {
            if (points > 0)
                _drawPointsView.text = $"x{points}";
            else
                _drawPointsView.text = $"<size=92>{TextIcons.BrokenHeart}</size>";
        }

        public void UpdateAvailableWordsOnField(int count) => _availableWordsOnFieldView.text = $"Доступно: {count}";
        public void UpdateHandCapacity(int current, int max) => _handCapacityView.text = $"Слов: {current}/{max}";
    }
}