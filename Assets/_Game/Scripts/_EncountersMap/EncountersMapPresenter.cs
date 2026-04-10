using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using R3;
using GameRoot;

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
            SetButtonStates();

            var centerNode = _model.MapGenerator.GetCenterNode();
            _model.EncounterButtonsMap[centerNode].Unlock();
            _model.EncounterButtonsMap[centerNode].SetCombat();
        }

        private void CreateEncountersNodes()
        {
            _model.MapGenerator.GenerateMap(_model.MapSize);
            _model.MapGenerator.CreateLinks();
            _model.MapGenerator.SetStageNumbers();
        }

        private void CreateEncounterButtons()
        {
            var encounterNodesMap = _model.MapGenerator.EncountersMap;
            var centerOffset = _model.MapGenerator.GetCenterCoordinates();

            foreach (var encounterNode in encounterNodesMap)
            {
                var coordinates = encounterNode.Key;
                var button = _view.CreateEncounterButton(
                    coordinates, centerOffset, _model.SpacingBetweenEncounterButtons);
                SetUpEncounterButton(button);
                _model.AddEncounterButton(encounterNode.Value, button);
            }
        }

        private void SetUpEncounterButton(EncounterButton button)
        {
            button.SelectedSignal.Subscribe(_ =>
            {
                _model.SelectedEncounterButton?.Deselect();
                button.Select();
                _model.SelectedEncounterButton = button;

                _view.UpdateGoToButton(!button.IsLocked);
                _view.UpdateAlreadyPassed(button.IsPassed);
            });
        }

        private void CreateLinks()
        {
            var alreadyLinked = new List<EncounterButton>();
            foreach (var encounterKvp in _model.EncounterButtonsMap)
            {
                var node = encounterKvp.Key;
                var button = encounterKvp.Value;
                var linkedButtons = _model.GetLinkedEncounterButtons(node);

                foreach (var linkedButton in linkedButtons)
                {
                    if (alreadyLinked.Contains(linkedButton)) continue;
                    _view.CreateLink(
                        button.RectTransform.anchoredPosition, linkedButton.RectTransform.anchoredPosition);
                }

                alreadyLinked.Add(button);
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

        private void SetButtonStates()
        {
            foreach (var encounterKvp in _model.EncounterButtonsMap)
            {
                var node = encounterKvp.Key;
                var button = encounterKvp.Value;

                if (_model.PassedEncounters.Contains(node.Number))
                    button.Complete();
                else if (node.LinkedNodes.Any(linkedNode => _model.PassedEncounters.Contains(linkedNode.Number)))
                    button.Unlock();
                else
                    button.Hide();
            }
        }
    }
}