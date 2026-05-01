using Configs;
using ObservableCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using R3;
using GameRoot;
using System;

namespace Gameplay
{
    public class Deck : IDisposable
    {
        private ObservableList<WordUnitConfigs> _allWordUnits;
        private CompositeDisposable _disposables = new();

        public IEnumerable<WordUnitConfigs> AllWordUnits => _allWordUnits;
        public IEnumerable<string> AllWords => _allWordUnits.Select(x => x.Name);
        public bool HasAnyWordUnit => _allWordUnits.Count > 0;

        public Deck(IEnumerable<WordUnitConfigs> wordUnits = null)
        {
            _allWordUnits = new ObservableList<WordUnitConfigs>();

            _allWordUnits.ObserveChanged()
                .Subscribe(_ => G.GameSessionProvider.SetWordsInDeck(AllWords))
                .AddTo(_disposables);

            if (wordUnits != null)
                Add(wordUnits);
        }

        public void Add(IEnumerable<WordUnitConfigs> wordUnits)
        {
            _allWordUnits.AddRange(wordUnits);
        }


        public void Add(WordUnitConfigs wordUnit)
        {
            _allWordUnits.Add(wordUnit);
        }

        public WordUnitConfigs DrawRandom()
        {
            if (_allWordUnits.Count == 0) return null;

            var index = UnityEngine.Random.Range(0, _allWordUnits.Count);
            var configs = _allWordUnits[index];
            _allWordUnits.RemoveAt(index);
            return configs;
        }

        public void Remove(WordUnitConfigs configs)
        {
            if (!_allWordUnits.Contains(configs)) return;
            _allWordUnits.Remove(configs);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}