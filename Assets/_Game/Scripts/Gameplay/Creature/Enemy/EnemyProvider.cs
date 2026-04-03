using Configs;
using GameRoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyProvider
    {
        private Enemy _currentEnemy;

        public Enemy CurrentEnemy => _currentEnemy;
    }
}