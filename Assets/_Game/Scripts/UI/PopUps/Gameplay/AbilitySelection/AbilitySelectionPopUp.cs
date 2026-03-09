using System;
using UnityEngine;
using R3;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace UI
{
    public class AbilitySelectionPopUp : PopUp
    {
        [Space]

        [SerializeField] private AbilitySelectionCard _cardPrefab;
        [SerializeField] private RectTransform _cardsCOuntainer;

        private List<AbilitySelectionCard> _createdCards = new();

        public override void Open()
        {
            CreateCards();
            Coroutines.Start(ShowCardsRoutine());

            base.Open();
        }

        private void CreateCards()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateCard(i);
            }
        }

        private void CreateCard(int idx)
        {
            var createdCard = Instantiate(_cardPrefab, _cardsCOuntainer, false);
            createdCard.SelectSignal.Subscribe(_ => SelectAbility(idx));

            _createdCards.Add(createdCard);
        }

        private IEnumerator ShowCardsRoutine()
        {
            yield return new WaitForSeconds(0.25f);
            foreach (var card in _createdCards)
            {
                card.Show();
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void SelectAbility(int idx)
        {
            Debug.Log($"Select ability idx: {idx}");
            Close();
        }
    }
}