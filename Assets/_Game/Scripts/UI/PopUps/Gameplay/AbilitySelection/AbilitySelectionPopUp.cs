using System;
using UnityEngine;
using R3;
using System.Collections;
using System.Collections.Generic;
using Utils;
using GameRoot;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class AbilitySelectionPopUp : PopUp
    {
        [Space]

        [SerializeField] private AbilitySelectionCard _cardPrefab;
        [SerializeField] private RectTransform _cardsCOuntainer;
        [SerializeField] private RectTransform _refuseButtonView;
        [SerializeField] private TMP_Text _hintView;

        private List<AbilitySelectionCard> _createdCards = new();

        public override void Open()
        {
            _refuseButtonView.localScale = new Vector2(0f, 1f);
            var hintColor = _hintView.color;
            hintColor.a = 0f;
            _hintView.color = hintColor;

            CreateCards();
            Coroutines.Start(ShowElementsRoutine());

            base.Open();
        }

        public override void Close()
        {
            Tween lastCardHiding = null;
            foreach (var card in _createdCards)
            {
                lastCardHiding = card.Hide();
            }

            if (lastCardHiding != null)
                lastCardHiding.OnComplete(() => base.Close());
            else
                base.Close();
        }

        public void Refuse()
        {
            Close();
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

        private IEnumerator ShowElementsRoutine()
        {
            yield return new WaitForSeconds(0.25f);

            Tween lastCardShowing = null;
            foreach (var card in _createdCards)
            {
                yield return new WaitForSeconds(0.05f);
                lastCardShowing = card.Show();
            }

            lastCardShowing.OnComplete(() =>
            {
                ShowRefuseButtonView();
                ShowHintView();
            });
        }

        private void ShowRefuseButtonView()
        {
            _refuseButtonView.DOScaleX(1, 0.5f).SetEase(Ease.OutBack);
        }

        private void ShowHintView()
        {
            _hintView.DOFade(1, 1f).SetEase(Ease.OutQuad);
        }

        private void SelectAbility(int idx)
        {
            Debug.Log($"Select ability idx: {idx}");
            Close();
        }
    }
}