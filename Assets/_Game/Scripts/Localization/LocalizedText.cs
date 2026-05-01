using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;
using Unity.VisualScripting;
using GameRoot;

namespace Localization
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private string _key;

        [Space]

        [SerializeField] private RectTransform[] _layoutsForRebuild;

        private void Awake()
        {
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
            var text = G.LocalizationProvider.GetTranslation(_key);

            if (TryGetComponent<TMP_Text>(out var view_tmp)) view_tmp.text = text;
            else if (TryGetComponent<Text>(out var view)) view.text = text;

            RebuildLayouts();
        }

        private void RebuildLayouts()
        {
            foreach (var layout in _layoutsForRebuild)
                LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
        }
    }
}