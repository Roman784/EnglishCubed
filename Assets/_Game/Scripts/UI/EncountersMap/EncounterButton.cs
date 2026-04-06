using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class EncounterButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;

        private RectTransform _rectTransform;

        public RectTransform RectTransform => _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetText(string text)
        {
            _view.text = text;
        }
    }
}