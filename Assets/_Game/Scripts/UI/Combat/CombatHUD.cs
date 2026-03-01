using R3;
using UnityEngine;

namespace UI
{
    public class CombatHUD : FullscreenUI
    {
        private Subject<Unit> _attackButtonPressedSignalSubj = new();
        public Observable<Unit> AttackButtonPressedSignal => _attackButtonPressedSignalSubj;
    }
}