using R3;
using UnityEngine;

namespace LevelMenu
{
    public class LevelMenuView : MonoBehaviour
    {
        private Subject<LevelName> _levelButtonPressedSignalSubj = new();
        private Subject<Unit> _exitButtonPressedSignalSubj = new();

        public Observable<LevelName> LevelButtonPressedSignal => _levelButtonPressedSignalSubj;
        public Observable<Unit> ExitButtonPressedSignal => _exitButtonPressedSignalSubj;

        public void PressForestPathButton() => _levelButtonPressedSignalSubj.OnNext(LevelName.ForestPath);
        public void PressExitButton() => _exitButtonPressedSignalSubj.OnNext(Unit.Default);
    }
}