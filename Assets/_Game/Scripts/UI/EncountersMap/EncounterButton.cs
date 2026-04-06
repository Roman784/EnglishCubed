using TMPro;
using UnityEngine;

namespace UI
{
    public class EncounterButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;

        public void SetText(string text)
        {
            _view.text = text;
        }
    }
}