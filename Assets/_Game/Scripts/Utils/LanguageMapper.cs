using Localization;
using UnityEngine;

namespace Utils
{
    public static class LanguageMapper
    {
        public static Language To(string lg)
        {
            return lg switch
            {
                "ru" => Language.Ru,
                "de" => Language.De,
                "es" => Language.Es,
                _ => Language.Ru
            };
        }
    }
}