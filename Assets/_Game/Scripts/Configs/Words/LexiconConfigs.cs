using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LexiconConfigs",
                     menuName = "Game Configs/Lexicon/New Lexicon Configs",
                     order = 0)]
    public class LexiconConfigs : ScriptableObject
    {
        public List<WordUnitConfigs> Adjectives;
        public List<WordUnitConfigs> Articles;
        public List<WordUnitConfigs> AuxiliaryVerbs;
        public List<WordUnitConfigs> LinkingVerbs;
        public List<WordUnitConfigs> Nouns;
        public List<WordUnitConfigs> Pronouns;
        public List<WordUnitConfigs> Verbs;

        private Dictionary<string, WordUnitConfigs> _allWordsMap;

        public WordUnitConfigs Lookup(string word)
        {
            if (_allWordsMap.ContainsKey(word))
                return _allWordsMap[word];
            return null;
        }

        private void OnValidate()
        {
            FillMap();
        }

        private void FillMap()
        {
            _allWordsMap = new Dictionary<string, WordUnitConfigs>();
            FillMap(Adjectives);
            FillMap(Articles);
            FillMap(AuxiliaryVerbs);
            FillMap(LinkingVerbs);
            FillMap(Nouns);
            FillMap(Pronouns);
            FillMap(Verbs);
        }

        private void FillMap(List<WordUnitConfigs> words)
        {
            foreach (var word in words)
            {
                if (word == null) continue;

                var key = word.Word.Text;
                if (_allWordsMap.ContainsKey(key))
                {
                    Debug.LogError($"Word {key} already in the lexicon!");
                    continue;
                }

                _allWordsMap[key] = word;
            }
        }
    }
}