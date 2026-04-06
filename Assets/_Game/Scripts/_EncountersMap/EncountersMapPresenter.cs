using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapPresenter
    {
        private EncountersMapView _view;
        private EncountersMapModel _model;

        public EncountersMapPresenter(EncountersMapView view, EncountersMapModel model)
        {
            _view = view;
            _model = model;

            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {

        }

        public void CreateMap()
        {
            CreateEncountersNodes();
            CreateEncounterButtons();
            CreateLinks();
            AdaptEncounterButtonsContainerSize();
        }

        private void CreateEncountersNodes()
        {
            _model.MapGenerator.GenerateMap(_model.MapSize);
            _model.MapGenerator.CreateLinks();
        }

        private void CreateEncounterButtons()
        {
            var encounterNodesMap = _model.MapGenerator.EncountersMap;
            var centerOffset = _model.MapGenerator.GetCenterOffset();

            foreach (var encounterNode in encounterNodesMap)
            {
                var coordinates = encounterNode.Key;
                var button = _view.CreateEncounterButton(
                    coordinates, centerOffset, _model.SpacingBetweenEncounterButtons);

                _model.AddEncounterButton(encounterNode.Value, button);
            }
        }

        private void CreateLinks()
        {
            var alreadyLinked = new List<EncounterButton>();
            foreach (var encounterNode in _model.EncounterButtonsMap)
            {
                var button = encounterNode.Value;
                var linkedButtons = _model.GetLinkedEncounterButtons(encounterNode.Key);
                foreach (var linkedButton in linkedButtons)
                {
                    if (alreadyLinked.Contains(linkedButton)) continue;
                    _view.CreateLink(button.RectTransform.anchoredPosition, linkedButton.RectTransform.anchoredPosition);
                }

                alreadyLinked.Add(encounterNode.Value);
            }
        }

        private void AdaptEncounterButtonsContainerSize()
        {
            var encounterButtons = _model.EncounterButtonsMap.Values;
            var minPositions = new Vector2(
                encounterButtons.Min(button => button.RectTransform.anchoredPosition.x),
                encounterButtons.Min(button => button.RectTransform.anchoredPosition.y));
            var maxPositions = new Vector2(
                encounterButtons.Max(button => button.RectTransform.anchoredPosition.x),
                encounterButtons.Max(button => button.RectTransform.anchoredPosition.y));
            _view.AdaptEncounterButtonsContainerSize(minPositions, maxPositions);
        }
    }
}