using GameRoot;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TheoryPopUp : PopUp
    {
        [SerializeField] private TMP_Text _titleView;
        [SerializeField] private TMP_Text _contentView;

        public void Open(string title, string content)
        {
            _titleView.text = G.LocalizationProvider.GetTranslation(title);
            _contentView.text = G.LocalizationProvider.GetTranslation(content);

            base.Open();
        }
    }
}