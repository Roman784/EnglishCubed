using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Configs
{
    [CreateAssetMenu(fileName = "GrammarHintsConfigs",
                     menuName = "Game Configs/Grammar/New Grammar Hints Configs",
                     order = 10)]
    public class GrammarHintsConfigs : ScriptableObject
    {
        public GrammarHint[] Hints;

        public string GetMessage(int code)
        {
            foreach (var hint in Hints)
            {
                if (hint.Code == code)
                    return hint.Messages[Random.Range(0, hint.Messages.Length)].Text;
            }

            return string.Empty;
        }
    }

    [Serializable]
    public class GrammarHint
    {
        [Serializable]
        public class Message
        {
            [TextArea(2, 3)] public string Text;
        }

        public int Code;
        public Message[] Messages;
    }
}