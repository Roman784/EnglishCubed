using DG.Tweening;
using Effects;
using GameRoot;
using R3;
using UnityEngine;

namespace UI
{
    public class CombatVictoryPopUp : PopUp
    {
        [SerializeField] CanvasGroup _menuButtonsView;
        [SerializeField] RectTransform _fanfareIcon;
        [SerializeField] Effect _conffetiEffect;

        public override PopUp SetInitialViewState()
        {
            base.SetInitialViewState();

            _menuButtonsView.alpha = 0f;
            _menuButtonsView.transform.localScale = new Vector2(0.5f, 0.5f);
            _fanfareIcon.localScale = Vector2.zero;

            return this;
        }

        public override void Open()
        {
            base.Open();

            Observable.Timer(System.TimeSpan.FromSeconds(1)).Subscribe(_ =>
            {
                ShowMenuButtonsView();
            });

            _fanfareIcon.DOScale(1f, 0.75f).SetEase(Ease.OutBack);
            Instantiate(_conffetiEffect, transform).Play();
        }

        public void ContinueGame()
        {
            Debug.Log("Contineu game");
            Close();
        }

        public void OpenLevelMenu()
        {
            G.SceneProvider.OpenLevelMenu();
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
    }
}