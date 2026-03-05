using Configs;
using UnityEngine;

namespace Gameplay
{
    public class WordUnitFactory
    {
        private WordUnit _prefab;

        public WordUnitFactory()
        {
            _prefab = Resources.Load<WordUnit>("Prefabs/WordUnit");
        }

        public WordUnit Create(WordUnitConfigs configs, Vector2 position, bool isZeroScale = true)
        {
            var wordUnit = Object.Instantiate(_prefab, position, Quaternion.identity)
                .SetConfigs(configs);

            if (isZeroScale)
                wordUnit.Transform.ZeroRootViewScale();

            return wordUnit;
        }
    }
}