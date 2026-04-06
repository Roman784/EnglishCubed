using UI;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapView : MonoBehaviour
    {
        [SerializeField] private RectTransform _encounterButtonsContainer;
        [SerializeField] private EncounterButton _encounterButtonPrefab;

        private void Start()
        {
            ClearEncountersButtonsContainer();
        }

        public EncounterButton CreateEncounterButton()
        {
            var button = Instantiate(_encounterButtonPrefab);
            AttachEncounterButton(button);
            return button;
        }

        private void AttachEncounterButton(EncounterButton button)
        {
            button.transform.SetParent(_encounterButtonsContainer, false);
            button.transform.localScale = Vector2.one;
        }

        private void ClearEncountersButtonsContainer()
        {
            foreach (Transform child in _encounterButtonsContainer)
                Destroy(child.gameObject);
        }
    }
}