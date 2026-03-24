using R3;
using Configs;

namespace Gameplay
{
    public class Experience : Stat
    {
        private readonly ExperienceLevelData[] _levelsData;
        private int _currentLevel;
        private bool _isNextLevelReached;

        public bool IsNextLevelReached => _isNextLevelReached;

        public Experience(ExperienceLevelData[] levelsData) : 
            base(StatName.Experience, 0, levelsData[0].Count)
        {
            _levelsData = levelsData;
            _currentLevel = 0;
            _isNextLevelReached = false;

            MaxReachedSignal.Subscribe(remainder =>
            {
                _isNextLevelReached = true;
            });
        }

        public void LevelUp()
        {
            _currentLevel += 1;
            var nextLevel = _levelsData[_currentLevel < _levelsData.Length ? _currentLevel : _levelsData.Length - 1];

            _max = nextLevel.Count;
            SetToZero();

            _isNextLevelReached = false;
        }
    }
}