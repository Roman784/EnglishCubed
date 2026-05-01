using GameRoot;
using UnityEngine;
using UnityEngine.UI;
using R3;
using System;
using System.Linq;

namespace Localization
{
    [RequireComponent(typeof(Image))]
    public class LocalizedImage : MonoBehaviour
    {
        [Serializable]
        private class LocalizedImageData
        {
            public Language Language;
            public Sprite Sprite;
        }

        [SerializeField] private LocalizedImageData[] _data;

        private Image _view;

        private void Awake()
        {
            _view = GetComponent<Image>();
            Localize();
        }

        public void Localize()
        {
            if (G.LocalizationProvider == null) return;

            G.LocalizationProvider.LanguageChangedSignal
                .Subscribe(_ => SetView())
                .AddTo(this);

            SetView();
        }

        private void SetView()
        {
            if (this == null) return;
            _view.sprite = _data
                .FirstOrDefault(d => d.Language == G.LocalizationProvider.CurrentLanguage).Sprite;
            _view.SetNativeSize();
        }
    }
}