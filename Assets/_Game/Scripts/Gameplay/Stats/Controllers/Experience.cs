using R3;
using Configs;
using UnityEngine;

namespace Gameplay
{
    public class Experience : Stat
    {
        private readonly ExperienceLevelData[] _levelsData;
        private int _currentLevel;
        private bool _isNextLevelReached;

        public int CurrentLevel => _currentLevel;
        public bool IsNextLevelReached => _isNextLevelReached;

        public Experience(ExperienceLevelData[] levelsData, int current, int level) : 
            base(StatName.Experience, current, levelsData[level].Count)
        {
            _levelsData = levelsData;
            _currentLevel = ClampLevel(level);
            _isNextLevelReached = false;

            MaxReachedSignal.Subscribe(remainder =>
            {
                _isNextLevelReached = true;
            });
        }

        public void LevelUp()
        {
            var nextLevel = ClampLevel(_currentLevel + 1);
            var nextLevelData = _levelsData[nextLevel];
            _currentLevel = nextLevel;

            _max = nextLevelData.Count;
            SetToZero();

            _isNextLevelReached = false;
        }

        private int ClampLevel(int level) => Mathf.Clamp(level, 0, _levelsData.Length - 1);
    }
}