using R3;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Gameplay
{
    public class Stat
    {
        protected int _max;
        protected ReactiveProperty<int> _current;

        // Contains excess.
        private Subject<int> _zeroReachedSignalSubj = new();
        private Subject<int> _maxReachedSignalSubj = new();

        public int Max => _max;
        public ReadOnlyReactiveProperty<int> Current => _current;
        public int CurrentValue => _current.CurrentValue;
        public float Rate => _current.Value / _max;
        public Subject<int> ZeroReachedSignal => _zeroReachedSignalSubj;
        public Subject<int> MaxReachedSignal => _maxReachedSignalSubj;

        public Stat(int current, int max)
        {
            _max = max;
            _current = new ReactiveProperty<int>(current);
        }

        public void SetMax(int newMax)
        {
            if (newMax < 0) newMax = 0;
            var difference = newMax - _max;
            _max = newMax;

            var newCurrentValue = Mathf.Max(_current.Value, _current.Value + difference);
            CheckAndApplyNewCurrentValue(newCurrentValue);
        }

        public void SetToZero() => _current.OnNext(0);
        public virtual void DecreaseOne() => Add(-1);
        public virtual void IncreaseOne() => Add(1);

        public void Add(int value)
        {
            var newCurrentValue = _current.Value + value;
            CheckAndApplyNewCurrentValue(newCurrentValue);
        }

        private void CheckAndApplyNewCurrentValue(int newValue)
        {
            _current.OnNext(Mathf.Clamp(newValue, 0, _max));

            if (_current.Value == 0)
                _zeroReachedSignalSubj.OnNext(newValue);
            else if (_current.Value == _max)
                _maxReachedSignalSubj.OnNext(newValue - _max);
        }
    }
}