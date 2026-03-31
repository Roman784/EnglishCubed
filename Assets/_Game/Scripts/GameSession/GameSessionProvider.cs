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
                Hero = baseOnData.Hero
            };
            SaveSession();
        }

        public void StartNewSession(CreatureName hero)
        {
            _sessionData = new GameSessionData() 
            { 
                IsStarted = true,
                Hero = hero 
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

        public void SetAbilities(IEnumerable<AbilitySaveData> abilities)
        {
            _sessionData.Abilities = abilities.ToArray();
            SaveSession();
        }

        private void SaveSession()
        {
            G.Repository.Session.SetData(_sessionData);
        }
    }
}