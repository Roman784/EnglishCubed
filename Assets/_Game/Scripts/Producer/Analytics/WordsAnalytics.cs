using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProducer
{
    public class WordsAnalytics
    {
        private Dictionary<string, int> _wordsUsesMap = new();

        public void IncreaseUses(string word)
        {
            if (!_wordsUsesMap.ContainsKey(word))
                _wordsUsesMap.Add(word, 0);
            _wordsUsesMap[word] += 1;

            NormilizeUsesCount();
        }

        public int GetUses(string word)
        {
            if (!_wordsUsesMap.ContainsKey(word))
                return 0;
            return _wordsUsesMap[word];
        }

        private void NormilizeUsesCount()
        {
            var min = _wordsUsesMap.Min(w => w.Value);
            foreach (var key in _wordsUsesMap.Keys.ToList())
                _wordsUsesMap[key] -= min;
        }
    }
}