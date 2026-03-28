using Configs;
using Gameplay;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HeroMenu
{
    public class HeroMenuModel
    {
        public HeroConfigs[] HeroConfigs { get; private set; }

        private IEnumerable<int> _unlockedHeroIndexes;
        private int _currentHeroIndex;
        private int _selectedHeroIndex;

        private int _displayedHeroIndex;

        public HeroMenuModel(
            HeroConfigs[] heroConfigs,
            IEnumerable<CreatureName> unlockedHeroes,
            CreatureName currentHeroName,
            CreatureName selectedHero)
        {
            HeroConfigs = heroConfigs;
            _unlockedHeroIndexes = new List<int>(unlockedHeroes.Select(h => GetHeroIndexByName(h)));
            _currentHeroIndex = GetHeroIndexByName(currentHeroName);
            _selectedHeroIndex = GetHeroIndexByName(selectedHero);

            _displayedHeroIndex = -1;
        }

        public void SetCurrentHeroIndex(int step)
        {
            _currentHeroIndex += step;

            if (_currentHeroIndex < 0)
                _currentHeroIndex = HeroConfigs.Length - 1;
            else if (_currentHeroIndex >= HeroConfigs.Length)
                _currentHeroIndex = 0;
        }

        public void SetDisplayedHero(CreatureName name)
        {
            _displayedHeroIndex = GetHeroIndexByName(name);
        }

        public HeroConfigs GetCurrentHeroConfigs()
        {
            return HeroConfigs[_currentHeroIndex];
        }

        public bool IsCurrentHeroSelected()
        {
            return _currentHeroIndex == _selectedHeroIndex;
        }

        public bool IsCurrentHeroUnlocked()
        {
            return _unlockedHeroIndexes.Contains(_currentHeroIndex);
        }

        public bool IsCurrentHeroAlreadyDisplayed()
        {
            return _currentHeroIndex == _displayedHeroIndex;
        }

        public void SelectCurrentHero()
        {
            _selectedHeroIndex = _currentHeroIndex;
        }

        public void UnlockCurrentHero()
        {
            _unlockedHeroIndexes = _unlockedHeroIndexes.Append(_currentHeroIndex);
        }

        private int GetHeroIndexByName(CreatureName name)
        {
            for (int i = 0; i < HeroConfigs.Length; i++)
            {
                if (HeroConfigs[i].Name == name)
                    return i;
            }
            Debug.LogError($"Failed to find hero with name {name}!");
            return 0;
        }
    }
}