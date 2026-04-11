using Abilities;
using Gameplay;
using GameRoot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
                Seed = GetNewSeed(),
                IsInEncounter = baseOnData.IsInEncounter,
                PassedEncounters = baseOnData.PassedEncounters,
                Hero = baseOnData.Hero,
                Abilities = baseOnData.Abilities,
                Stats = baseOnData.Stats,
                Experience = baseOnData.Experience,
            };
            SaveSession();
        }

        public void StartNewSession(CreatureName hero)
        {
            _sessionData = new GameSessionData()
            {
                IsStarted = true,
                Seed = GetNewSeed(),
                IsInEncounter = false,
                PassedEncounters = new int[0],
                Hero = hero,
                Abilities = new AbilitySaveData[0],
                Stats = new StatData[0],
                Experience = new ExperienceSaveData(),
            };
            SaveSession();
        }
        public void EndSession()
        {
            _sessionData.IsStarted = false;
            SaveSession();
        }

        public void SetHero(CreatureName hero)
        {
            _sessionData.Hero = hero;
            SaveSession();
        }

        public void SetCurrentEncounterNumber(int number)
        {
            _sessionData.CurrentEncounterNumber = number;
            SaveSession();
        }

        public void AddPassedEncounter(int passedEncounter)
        {
            if (_sessionData.PassedEncounters.Contains(passedEncounter)) return;
            _sessionData.PassedEncounters =
                _sessionData.PassedEncounters.Append(passedEncounter).ToArray();
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