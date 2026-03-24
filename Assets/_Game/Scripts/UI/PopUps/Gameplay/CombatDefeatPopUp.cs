using DG.Tweening;
using GameRoot;
using R3;
using UnityEngine;

namespace UI
{
    public class CombatDefeatPopUp : PopUp
    {
        [SerializeField] CanvasGroup _openLevelMenuButtonView;
        [SerializeField] RectTransform _heartIcon;

        public override PopUp SetInitialViewState()
        {
            base.SetInitialViewState();

            _openLevelMenuButtonView.alpha = 0f;
            _openLevelMenuButtonView.transform.localScale = new Vector2(0.5f, 0.5f);

            return this;
        }

        public override void Open()
        {
            base.Open();

            Observable.Timer(System.TimeSpan.FromSeconds(1)).Subscribe(_ =>
            {
                ShowOpenLevelMenuButtonView();
            });
        }

        public void OpenLevelMenu()
        {
            G.SceneProvider.OpenLevelMenu();
        }

        public void ShowMessage()
        {
            G.UIRoot.ShowMessage("Ты проиграл, на этом твоему пути конец"); // Loc.
        }

        private void Update()
        {
            var rotation = Mathf.Sin(Time.time * 1.5f) * 10f + 10f;
            _heartIcon.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }

        private void ShowOpenLevelMenuButtonView()
        {
            _openLevelMenuButtonView.DOFade(1, 0.5f).SetEase(Ease.OutQuad);
            _openLevelMenuButtonView.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }
    }
}