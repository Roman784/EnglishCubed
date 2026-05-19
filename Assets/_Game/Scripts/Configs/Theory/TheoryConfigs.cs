using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "TheoryConfigs",
                     menuName = "Game Configs/Theory/TheoryConfigs")]
    public class TheoryConfigs : ScriptableObject
    {
       public string Title;
       public string Content;
    }
}