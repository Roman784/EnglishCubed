using Configs;
using DG.Tweening;
using R3;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Gameplay
{
    public class WordUnit : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] private Transform _rootView;
        [SerializeField] private RectTransform _containerView;
        [SerializeField] private TMP_Text _wordView;
        [SerializeField] private RectTransform _backplate;

        [Header("Container Size")]
        [SerializeField] private float _containerBorderWidth;
        [SerializeField] private float _minContainerWidth;

        [Space]

        [SerializeField] private PointerDetector _pointerDetector;

        private WordUnitConfigs _configs;
        private WordUnitDragging _dragging;

        public Vector2 Position => transform.position;
        public RectTransform Backplate => _backplate;
        public WordUnitDragging Dragging => _dragging;
        public Vector2 ContainerSize => _containerView.sizeDelta;
        public Observable<PointerEventData> OnPointerClickSignal => _pointerDetector.OnPointerClickSignal;

        private void Start()
        {
            _dragging = new WordUnitDragging(transform);

            InitBehavior();
        }

        public WordUnit SetConfigs(WordUnitConfigs configs)
        {
            _configs = configs;
            SetWord(_configs.EnWord);

            return this;
        }

        private void InitBehavior()
        {
            var behaviorHandler = new WordUnitBehaviorHandler(this);
            _pointerDetector.OnPointerEnterSignal.Subscribe(_ => behaviorHandler.HandleOnPointerEnter());
            _pointerDetector.OnPointerExitSignal.Subscribe(_ => behaviorHandler.HandleOnPointerExit());
            _pointerDetector.OnPointerDownSignal.Subscribe(_ => behaviorHandler.HandleOnPointerDown());
            _pointerDetector.OnPointerUpSignal.Subscribe(_ => behaviorHandler.HandleOnPointerUp());
            _pointerDetector.OnPointerClickSignal.Subscribe(_ => behaviorHandler.HandleOnPointerClick());
            behaviorHandler.SetInHandBehavior();
        }

        public void MoveTo(Vector2 to)
        {
            transform.DOMove(to, 0.25f).SetEase(Ease.OutQuad);
        }

        public void MoveToByDecreasing(Vector2 position, float scale)
        {
            _rootView.DOScale(0, 0.15f).OnComplete(() =>
            {
                transform.position = position;
                _rootView.DOScale(scale, 0.2f).SetEase(Ease.OutBack);
            });
        }

        private void SetWord(string word)
        {
            _wordView.text = word;

            var newContainerWidth = _wordView.preferredWidth + _containerBorderWidth * 2f;
            newContainerWidth = Mathf.Max(_minContainerWidth, newContainerWidth);
            _containerView.sizeDelta = new Vector2(newContainerWidth, 1);
        }
    }
}