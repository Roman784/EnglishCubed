using R3;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

namespace Gameplay
{
    public class Stat
    {
        public readonly StatName Name;

        protected float _max;
        protected ReactiveProperty<float> _current;

        // Contains excess.
        private Subject<float> _zeroReachedSignalSubj = new();
        private Subject<float> _maxReachedSignalSubj = new();

        public float Max => _max;
        public ReadOnlyReactiveProperty<float> Current => _current;
        public float CurrentValue => _current.CurrentValue;
        public float Rate => _current.Value / _max;
        public Subject<float> ZeroReachedSignal => _zeroReachedSignalSubj;
        public Subject<float> MaxReachedSignal => _maxReachedSignalSubj;

        public Stat(StatName name, float current, float max)
        {
            Name = name;
            _max = max;
            _current = new ReactiveProperty<float>(current);
        }

        public override string ToString()
        {
            return $"{Name}: {CurrentValue}/{Max}";
        }

        public void SetMax(float newMax)
        {
            if (newMax < 0) newMax = 0;
            var difference = newMax - _max;
            _max = newMax;

            var newCurrentValue = Mathf.Max(_current.Value, _current.Value + difference);
            CheckAndApplyNewCurrentValue(newCurrentValue);
        }

        public void SetToZero() => _current.OnNext(0);
        public virtual void IncreaseOne() => Add(1);
        public virtual void DecreaseOne() => Subtract(1);

        public void Add(float value)
        {
            var newCurrentValue = _current.Value + value;
            CheckAndApplyNewCurrentValue(newCurrentValue);
        }

        public void Subtract(float value)
        {
            var newCurrentValue = _current.Value - value;
            CheckAndApplyNewCurrentValue(newCurrentValue);
        }

        public void RestoreFull()
        {
            CheckAndApplyNewCurrentValue(_max);
        }

        private void CheckAndApplyNewCurrentValue(float newValue)
        {
            _current.OnNext(Mathf.Clamp(newValue, 0, _max));

            if (_current.Value == 0)
                _zeroReachedSignalSubj.OnNext(newValue);
            else if (_current.Value == _max)
                _maxReachedSignalSubj.OnNext(newValue - _max);
        }
    }
}