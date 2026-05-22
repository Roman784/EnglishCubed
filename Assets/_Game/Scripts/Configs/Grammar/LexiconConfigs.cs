using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LexiconConfigs",
                     menuName = "Game Configs/Grammar/New Lexicon Configs",
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
        public List<WordUnitConfigs> Marks;

        private Dictionary<string, WordUnitConfigs> _allWordsMap;
        private Dictionary<string, WordUnitConfigs> _allWordsByNameMap;

        public IEnumerable<WordUnitConfigs> AllWords => _allWordsByNameMap.Values;

        private void Awake()
        {
            FillMap();
        }

        public WordUnitConfigs GetByName(string name)
        {
            if (_allWordsByNameMap.ContainsKey(name))
                return _allWordsByNameMap[name];
            return null;
        }

        public WordUnitConfigs Lookup(string word)
        {
            if (_allWordsMap.ContainsKey(word))
                return _allWordsMap[word];
            return null;
        }

        private void FillMap()
        {
            _allWordsByNameMap = new Dictionary<string, WordUnitConfigs>();
            FillMap(Adjectives);
            FillMap(Articles);
            FillMap(AuxiliaryVerbs);
            FillMap(LinkingVerbs);
            FillMap(Nouns);
            FillMap(Pronouns);
            FillMap(Verbs);
            FillMap(Marks);

            _allWordsMap = new Dictionary<string, WordUnitConfigs>();
            _allWordsMap = _allWordsByNameMap.Select(kvp => 
                new KeyValuePair<string, WordUnitConfigs>(kvp.Value.Definition.Text, kvp.Value))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private void FillMap(List<WordUnitConfigs> words)
        {
            foreach (var word in words)
            {
                if (word == null) continue;

                var key = word.Name;
                if (_allWordsByNameMap.ContainsKey(key))
                {
                    Debug.LogError($"Word {key} already in the lexicon!");
                    continue;
                }

                _allWordsByNameMap[key] = word;
            }
        }
    }
}