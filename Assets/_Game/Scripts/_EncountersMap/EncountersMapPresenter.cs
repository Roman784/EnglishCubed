using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using R3;
using GameRoot;
using System;

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
            _view.GoToEncounterButtonPressedSignal
                .Subscribe(_ => OpenSelectedEncounter());

            _view.ExitButtonPressedSignal
                .Subscribe(_ => OpenMainMenu()); 
        }

        public void CreateMap()
        {
            CreateEncountersNodes();
            CreateEncounterButtons();
            CreateLinks();
            AdaptEncounterButtonsContainerSize();
            SetUpButtons();
            SetCenterNode();
            SetBossCombatNode();

            G.GameSessionProvider.SetTotalEncountersCount(
                _model.MapGenerator.NodesCount);
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
                _model.AddEncounterButton(encounterNode.Value, button);
            }
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

        private void SetUpButtons()
        {
            foreach (var encounterKvp in _model.EncounterButtonsMap)
            {
                var node = encounterKvp.Key;
                var button = encounterKvp.Value;

                SetButtonSelection(button);
                SetButtonState(node, button);
                SetButtonName(button);
            }
        }

        private void SetButtonSelection(EncounterButton button)
        {
            button.SelectedSignal.Subscribe(_ =>
            {
                _model.SelectedEncounterButton?.Deselect();
                _model.SelectedEncounterButton = button;
                button.Select();

                _view.UpdateGoToButton(!(button.IsUnknown || button.IsPassed));
                _view.UpdateAlreadyPassed(button.IsPassed);
            });
        }

        private void SetButtonState(EncounterNode node, EncounterButton button)
        {
            if (_model.PassedEncounters.Contains(node.Number))
                button.Complete();
            else if (!node.LinkedNodes.Any(linkedNode => _model.PassedEncounters.Contains(linkedNode.Number)))
                button.SetUnknown(true);
        }

        private void SetButtonName(EncounterButton button)
        {
            if (button.IsUnknown || button.IsPassed) return;

            var name = G.GameProducer.Encounter.GetEncounterName();
            button.SetName(name);
        }

        private void SetCenterNode()
        {
            var centerNode = _model.MapGenerator.GetCenterNode();
            var button = _model.EncounterButtonsMap[centerNode];
            
            button.SetUnknown(false);
            if (!button.IsPassed)
                button.SetName(EncounterName.Combat);
        }

        private void SetBossCombatNode()
        {
            var validateNodes = _model.MapGenerator.GetEdgeNodes().ToArray();
            var node = validateNodes[UnityEngine.Random.Range(0, validateNodes.Length)];
            var button = _model.EncounterButtonsMap[node];
            
            if (button.IsUnknown) return;
            button.SetName(EncounterName.BossCombat);
        }

        private void OpenSelectedEncounter()
        {
            var selectedButton = _model.SelectedEncounterButton;
            var encounterName = selectedButton.Name;
            var encounterNumber = _model.GetNode(selectedButton).Number;

            switch (encounterName)
            {
                case EncounterName.Combat:
                case EncounterName.EmergencyCombat:
                case EncounterName.BossCombat:
                    G.SceneProvider.OpenCombat(encounterName, encounterNumber);
                    break;
            }
        }

        private void OpenMainMenu()
        {
            G.SceneProvider.OpenMainMenu();
        }
    }
}