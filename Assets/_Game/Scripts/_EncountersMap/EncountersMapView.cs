using DG.Tweening;
using UI;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapView : MonoBehaviour
    {
        [SerializeField] private RectTransform _encounterButtonsContainer;
        [SerializeField] private EncounterButton _encounterButtonPrefab;
        [SerializeField] private LineRenderer _linkLinePrefab;

        [Space]

        [SerializeField] private Transform _goToButtonView;
        [SerializeField] private Transform _alreadyPassedView;

        private void Start()
        {
            ClearEncountersButtonsContainer();
        }

        public EncounterButton CreateEncounterButton(
            Vector2Int coordinates, Vector2Int offset, float spacing)
        {
            var button = Instantiate(_encounterButtonPrefab);
            var position = GetEncounterButtonPoisition(coordinates, offset, spacing);
            AttachEncounterButton(button, position);
            return button;
        }

        public void CreateLink(Vector2 from, Vector2 to)
        {
            var link = Instantiate(_linkLinePrefab, _encounterButtonsContainer, false);
            link.positionCount = 2;
            link.SetPosition(0, from);
            link.SetPosition(1, to);
        }

        public void AdaptEncounterButtonsContainerSize(Vector2 minPositions, Vector2 maxPositions)
        {
            var screenSize = new Vector2(Screen.width, Screen.height);
            var defaultContainerSize = maxPositions - minPositions;
            _encounterButtonsContainer.sizeDelta = defaultContainerSize + screenSize * 0.75f;
        }

        public void UpdateGoToButton(bool isActive)
        {
            SetActiveView(_goToButtonView, isActive);
        }

        public void UpdateAlreadyPassed(bool isActive)
        {
            SetActiveView(_alreadyPassedView, isActive);
        }

        private void AttachEncounterButton(EncounterButton button, Vector2 position)
        {
            button.transform.SetParent(_encounterButtonsContainer, false);
            button.transform.localScale = Vector2.one;
            button.RectTransform.anchoredPosition = position;
        }

        private void ClearEncountersButtonsContainer()
        {
            foreach (Transform child in _encounterButtonsContainer)
                Destroy(child.gameObject);
        }

        private Vector2 GetEncounterButtonPoisition(Vector2Int coordinates, Vector2Int offset, float spacing)
        {
            coordinates -= offset;

            if (coordinates == Vector2Int.zero)
                return Vector2.zero;

            var orbitIndex = Mathf.Max(Mathf.Abs(coordinates.x), Mathf.Abs(coordinates.y));
            var orbitRadius = orbitIndex * spacing;
            var angle = Mathf.Atan2(coordinates.y, coordinates.x);
            var angularStep = 2f * Mathf.PI / (8f * orbitIndex);
            var elementIndex = Mathf.RoundToInt(angle / angularStep);
            angle = elementIndex * angularStep;

            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);

            return new Vector2(x, y) * orbitRadius;
        }

        private void SetActiveView(Transform view, bool isActive)
        {
            if (view.gameObject.activeSelf == isActive) return;
            view.gameObject.SetActive(isActive);
            view.DOKill(true);
            view.DOPunchScale(Vector2.one * 0.05f, 0.35f, 6).SetEase(Ease.OutQuad);
        }
    }
}