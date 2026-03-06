using UnityEngine;
using R3;

namespace Gameplay
{
    public class Experience : Stat
    {
        private Subject<Unit> _levelUppedSignalSubj = new();
        public Observable<Unit> LevelUppedSignal => _levelUppedSignalSubj;

        public Experience(int current, int max) : base(current, max)
        {
            MaxReachedSignal.Subscribe(remainder =>
            {
                LevelUp();
            });
        }


        private void LevelUp()
        {
            Debug.Log("LevelUp");

            SetToZero();
            _levelUppedSignalSubj.OnNext(Unit.Default);
        }
    }
}