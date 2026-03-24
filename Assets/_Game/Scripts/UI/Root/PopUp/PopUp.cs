using DG.Tweening;
using R3;
using UnityEngine;
using Utils;

namespace UI
{
    public abstract class PopUp : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup _rootView;
        [SerializeField] private RectTransform _titleViewport;

        [Space]

        [SerializeField] private float _initialScale = 0.9f;
        [SerializeField] protected TweenData _openTweenData = 
            new TweenData { Duration = 0.1f, Ease = Ease.OutBack };
        [SerializeField]
        protected TweenData _closeTweenData =
            new TweenData { Duration = 0.2f, Ease = Ease.Linear };

        private Subject<Unit> _closeSignalSubj = new();
        private Tweener _openTween;

        public Observable<Unit> CloseSignal => _closeSignalSubj;

        public virtual PopUp SetInitialViewState()
        {
            _rootView.transform.localScale = Vector3.one * _initialScale;
            if (_titleViewport != null) _titleViewport.localScale = Vector2.up;
            return this;
        }

        public virtual void Open()
        {
            _openTween = _rootView.transform
                .DOScale(1, _openTweenData.Duration)
                .SetEase(_openTweenData.Ease);
            _rootView.alpha = 1f;

            ShowTitle();
        }

        public virtual void Close()
        {
            _rootView.DOFade(0, _closeTweenData.Duration)
                .SetEase(_closeTweenData.Ease)
                .OnComplete(() =>
                {
                    _rootView.gameObject.SetActive(false);

                    _closeSignalSubj.OnNext(Unit.Default);
                    _closeSignalSubj.OnCompleted();
                });
        }

        protected void ShowTitle()
        {
            _titleViewport.DOScaleX(1, 0.5f).SetEase(Ease.OutBack);
        }

        public void Destroy()
        {
            _openTween?.Kill();
            Destroy(gameObject);
        }
    }
}