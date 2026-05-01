using R3;

namespace Localization
{
    public interface ILocalizationProvider
    {
        public bool IsTranslationsLoaded { get; }
        public Language CurrentLanguage { get; }
        public Observable<Unit> LanguageChangedSignal { get; }

        public Observable<bool> LoadTranslations(Language language);
        public string GetTranslation(string key);
        public string GetTranslation(string key, params string[] additiveValues);
        public void ChangeLanguage(Language language);
    }
}
