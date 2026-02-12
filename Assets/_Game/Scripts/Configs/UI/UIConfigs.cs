using UI;
using UnityEngine;

namespace GameRoot
{
    [CreateAssetMenu(fileName = "UIConfigs",
                     menuName = "Game Configs/UI/New UI Configs")]
    public class UIConfigs : ScriptableObject
    {
        [Header("Root")]
        public UIRoot Root;
    }
}
