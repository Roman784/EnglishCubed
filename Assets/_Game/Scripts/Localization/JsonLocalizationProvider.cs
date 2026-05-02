using GameRoot;
using R3;
using System.Collections.Generic;
using UnityEngine;

namespace Localization
{
    public class JsonLocalizationProvider : ILocalizationProvider
    {
        private static Dictionary<Language, string> _pathsMap = new()
        {
            { Language.Ru, $"Localization/TRANSLATIONS_RU" }
        };

        private Dictionary<string, string> _tranlationsMap;
        private Subject<Unit> _languageChangedSignalSubj = new();

        public bool IsTranslationsLoaded { get; private set; }
        public Language CurrentLanguage { get; private set; }
        public Observable<Unit> LanguageChangedSignal => _languageChangedSignalSubj;

        public Observable<bool> LoadTranslations(Language language)
        {
            if (!_pathsMap.ContainsKey(language)) return Observable.Return(false);

            var json = Resources.Load<TextAsset>(_pathsMap[language]);

            if (json == null)
            {
                Debug.LogError($"Language file not found: {language}");
                return Observable.Return(false);
            }

            var data = JsonUtility.FromJson<LocalizationData>(json.text);

            _tranlationsMap = new Dictionary<string, string>();
            foreach (var item in data.Items)
            {
                _tranlationsMap[item.Key] = item.Value;
            }

            CurrentLanguage = language;
            IsTranslationsLoaded = true;
            return Observable.Return(true);
        }

        public string GetTranslation(string key)
        {
            if (_tranlationsMap == null)
            {
                Debug.LogWarning("Localization not initialized! Loading default language.");
                LoadTranslations(Language.Ru);
            }

            if (_tranlationsMap.TryGetValue(key, out var translatedValue))
                return translatedValue;
            return $"MISSING: {key}";
        }

        public string GetTranslation(string key, params string[] additiveValues)
        {
            var translatedValue = GetTranslation(key);

            for (int i = 0; i < additiveValues.Length; i++)
            {
                var reg =  "{" + i.ToString() + "}";
                if (translatedValue.Contains(reg))
                    translatedValue = translatedValue.Replace(reg, additiveValues[i]);
            }

            return translatedValue;
        }

        public void ChangeLanguage(Language language)
        {
            LoadTranslations(language).Subscribe(res =>
            {
                if (res)
                    _languageChangedSignalSubj.OnNext(Unit.Default);
                else
                    Debug.LogWarning($"Failed to change language to {language}!");
            });

            G.Repository.Language.SetLanguage(language);
        }
    }
}