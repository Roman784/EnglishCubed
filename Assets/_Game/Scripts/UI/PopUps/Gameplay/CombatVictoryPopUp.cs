using DG.Tweening;
using Effects;
using GameRoot;
using R3;
using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class CombatVictoryPopUp : PopUp
    {
        [Space]

        [SerializeField] TMP_Text _earnedСoinsView;
        [SerializeField] CanvasGroup _menuButtonsView;
        [SerializeField] RectTransform _fanfareIcon;
        [SerializeField] Effect _conffetiEffect;

        public override PopUp SetInitialViewState()
        {
            base.SetInitialViewState();

            _menuButtonsView.alpha = 0f;
            _menuButtonsView.transform.localScale = new Vector2(0.5f, 0.5f);
            _fanfareIcon.localScale = Vector2.zero;
            _earnedСoinsView.transform.localScale = Vector2.zero;

            return this;
        }

        public void Open(int earnedСoins)
        {
            base.Open();

            Observable.Timer(System.TimeSpan.FromSeconds(1)).Subscribe(_ =>
            {
                ShowMenuButtonsView();
                ShowEarnedCoins(earnedСoins);
            });

            _fanfareIcon.DOScale(1f, 0.75f).SetEase(Ease.OutBack);
            Instantiate(_conffetiEffect, transform).Play();
        }

        public void ContinueGame()
        {
            G.SceneProvider.OpenEncountersMap();
        }

        public void OpenLevelMenu()
        {
            G.SceneProvider.OpenMainMenu();
        }

        public void ShowMessage()
        {
            G.UIRoot.ShowMessage("Победа! Остановишься здесь или пойдёшь дальше?"); // Loc.
        }

        private void Update()
        {
            var rotation = Mathf.Sin(Time.time * 1.5f) * 10f;
            _fanfareIcon.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }

        private void ShowMenuButtonsView()
        {
            _menuButtonsView.DOFade(1, 0.5f).SetEase(Ease.OutQuad);
            _menuButtonsView.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }

        private void ShowEarnedCoins(int earnedСoins)
        {
            int currentValue = 0;
            _earnedСoinsView.text = currentValue.ToCoinsFormat();

            var seq = DOTween.Sequence();
            seq.Append(_earnedСoinsView.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
            seq.Append(_earnedСoinsView.transform.DOShakeScale(2.5f, 0.25f));
            seq.Join
            (
                DOTween.To
                (
                    () => currentValue,
                    c =>
                    {
                        currentValue = c;
                        _earnedСoinsView.text = currentValue.ToCoinsFormat();
                    },
                    earnedСoins,
                    2.5f
                )
                .SetEase(Ease.OutCirc)
            );
        }
    }
}