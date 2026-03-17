using Abilities;
using Configs;
using DG.Tweening;
using GameRoot;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class AbilitySelectionPopUp : PopUp
    {
        [Space]

        [SerializeField] private RectTransform _titleViewport;

        [Space]

        [SerializeField] private AbilitySelectionCard _cardPrefab;
        [SerializeField] private RectTransform _cardsCOuntainer;
        [SerializeField] private CanvasGroup _refuseButtonView;
        [SerializeField] private TMP_Text _hintView;

        private List<AbilitySelectionCard> _createdCards = new();

        public override PopUp SetInitialViewState()
        {
            base.SetInitialViewState();

            _titleViewport.localScale = Vector2.up;
            _refuseButtonView.alpha = 0f;
            _refuseButtonView.transform.localScale = new Vector2(0.5f, 0.5f);
            var hintColor = _hintView.color;
            hintColor.a = 0f;
            _hintView.color = hintColor;

            return this;
        }

        public void Open(IEnumerable<AbilityConfigs> abilitiesConfigs)
        {
            SetInitialViewState();
            ShowTitle();

            CreateCards(abilitiesConfigs);
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

        private void CreateCards(IEnumerable<AbilityConfigs> abilitiesConfigs)
        {
            foreach (var abilityConfigs in abilitiesConfigs)
            {
                CreateCard(abilityConfigs);
            }
        }

        private void CreateCard(AbilityConfigs abilityConfigs)
        {
            var createdCard = Instantiate(_cardPrefab, _cardsCOuntainer, false);
            createdCard.SetConfigs(abilityConfigs);
            createdCard.SelectSignal.Subscribe(_ => SelectAbility(abilityConfigs.Name));

            _createdCards.Add(createdCard);
        }

        private IEnumerator ShowElementsRoutine()
        {
            yield return new WaitForSeconds(0.25f);

            Observable<Unit> lastCardShowedSignal = null;
            foreach (var card in _createdCards)
            {
                yield return new WaitForSeconds(0.05f);
                lastCardShowedSignal = card.Show();
            }

            lastCardShowedSignal.Subscribe(_ =>
            {
                ShowRefuseButtonView();
                ShowHintView();
            });
        }

        private void ShowTitle()
        {
            _titleViewport.DOScaleX(1, 0.5f).SetEase(Ease.OutBack);
        }

        private void ShowRefuseButtonView()
        {
            _refuseButtonView.DOFade(1, 0.5f).SetEase(Ease.OutQuad);
            _refuseButtonView.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }

        private void ShowHintView()
        {
            _hintView.DOFade(1, 1f).SetEase(Ease.OutQuad);
        }

        private void SelectAbility(AbilityName abilityName)
        {
            Debug.Log($"Select ability idx: {abilityName}");
            Close();
        }
    }
}