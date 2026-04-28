using Abilities;
using EncountersMap;
using Gameplay;
using GameRoot;
using LevelMenu;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Accessibility;

namespace GameSession
{
    public class GameSessionProvider
    {
        private GameSessionData _sessionData;

        public bool IsSessionStarted => _sessionData != null && _sessionData.IsStarted;
        public GameSessionData SessionData => _sessionData;

        public GameSessionProvider()
        {
            _sessionData = G.Repository.Session.GetData();
        }

        public void StartNewSession(GameSessionData baseOnData)
        {
            _sessionData = new GameSessionData()
            {
                IsStarted = true,
                Seed = baseOnData.Seed,
                IsInEncounter = baseOnData.IsInEncounter,
                TotalEncountersCount = baseOnData.TotalEncountersCount,
                PassedEncounters = new List<int>(baseOnData.PassedEncounters).ToArray(),
                Hero = baseOnData.Hero,
                Level = baseOnData.Level,
                Abilities = new List<AbilitySaveData>(baseOnData.Abilities).ToArray(),
                Stats = new List<StatData>(baseOnData.Stats).ToArray(),
                Experience = baseOnData.Experience,
                IsEnemyExist = baseOnData.IsEnemyExist,
                Enemy = baseOnData.Enemy,
                CurrentEnemyHealth = baseOnData.CurrentEnemyHealth,
                MaxEnemyHealth = baseOnData.MaxEnemyHealth
            };
            SaveSession();
        }

        public void StartNewSession(CreatureName hero, LevelName level)
        {
            _sessionData = new GameSessionData()
            {
                IsStarted = true,
                Seed = GetNewSeed(),
                IsInEncounter = false,
                TotalEncountersCount = 1,
                CurrentEncounterNumber = -1,
                PassedEncounters = new int[0],
                Hero = hero,
                Level = level,
                Abilities = new AbilitySaveData[0],
                Stats = new StatData[0],
                Experience = new ExperienceSaveData(),
                IsEnemyExist = false,
                Enemy = CreatureName.None,
                CurrentEnemyHealth = 0,
                MaxEnemyHealth = 0
            };
            SaveSession();
        }

        public void EndSession()
        {
            _sessionData.IsStarted = false;
            _sessionData.IsInEncounter = false;
            _sessionData.CurrentEncounterName = EncounterName.None;
            _sessionData.CurrentEncounterNumber = -1;
            SaveSession();
        }

        public void SetIsInEncounter(bool value)
        {
            _sessionData.IsInEncounter = value;
            SaveSession();
        }

        public void SetCurrentEncounterName(EncounterName name)
        {
            _sessionData.CurrentEncounterName = name;
            SaveSession();
        }

        public void SetCurrentEncounterNumber(int number)
        {
            _sessionData.CurrentEncounterNumber = number;
            SaveSession();
        }

        public void SetTotalEncountersCount(int count)
        {
            _sessionData.TotalEncountersCount = count;
            SaveSession();
        }

        public void AddPassedEncounter(int number)
        {
            if (_sessionData.PassedEncounters.Contains(number)) return;
            _sessionData.PassedEncounters =
                _sessionData.PassedEncounters.Append(number).ToArray();
            SaveSession();
        }

        public void SetAbilities(IEnumerable<AbilitySaveData> abilities)
        {
            _sessionData.Abilities = abilities.ToArray();
            SaveSession();
        }

        public void SetStats(IEnumerable<StatData> stats)
        {
            _sessionData.Stats = stats
                .Where(s => s.Name != StatName.Experience)
                .ToArray();
            SaveSession();
        }

        public void SetExperience(ExperienceSaveData data)
        {
            _sessionData.Experience = data;
            SaveSession();
        }

        public void SetIsEnemyExist(bool isExist)
        {
            _sessionData.IsEnemyExist = isExist;
            SaveSession();
        }

        public void SetEnemy(CreatureName enemy)
        {
            _sessionData.Enemy = enemy;
            SaveSession();
        }

        public void SetCurrentEnemyHealth(int health)
        {
            _sessionData.CurrentEnemyHealth = health;
            SaveSession();
        }

        public void SetMaxEnemyHealth(int health)
        {
            _sessionData.MaxEnemyHealth = health;
            SaveSession();
        }

        private void SaveSession()
        {
            G.Repository.Session.SetData(_sessionData);
        }

        private int GetNewSeed()
        {
            return Random.Range(10000000, 99999999);
        }
    }
}