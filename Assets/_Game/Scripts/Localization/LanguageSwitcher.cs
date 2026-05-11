using GameRoot;
using UnityEngine;

namespace Localization
{
    public class LanguageSwitcher : MonoBehaviour
    {
        public void SetRuLanguage()
        {
            SetLanguage(Language.Ru);
        }

        public void SetDeLanguage()
        {
            SetLanguage(Language.De);
        }

        public void SetEsLanguage()
        {
            SetLanguage(Language.Es);
        }

        public void SetLanguage(Language language)
        {
            G.LocalizationProvider.ChangeLanguage(language);
        }
    }
}