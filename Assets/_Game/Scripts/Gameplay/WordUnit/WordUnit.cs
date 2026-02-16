using Configs;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Gameplay
{
    public class WordUnit : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] private RectTransform _containerView;
        [SerializeField] private TMP_Text _wordView;

        [Header("Container Size")]
        [SerializeField] private float _containerBorderWidth;
        [SerializeField] private float _minContainerWidth;

        [Space]

        [SerializeField] private PointerDetector _pointerDetector;

        private WordUnitConfigs _configs;

        public Vector2 ContainerSize => _containerView.sizeDelta;
        public Observable<PointerEventData> OnPointerClickSignal => _pointerDetector.OnPointerClickSignal;

        private void Start()
        {
            var behaviorHandler = new WordUnitBehaviorHandler(this);
            _pointerDetector.OnPointerClickSignal.Subscribe(_ => behaviorHandler.HandleOnClick());
            behaviorHandler.SetInHandBehavior();
        }

        public WordUnit SetConfigs(WordUnitConfigs configs)
        {
            _configs = configs;
            SetWord(_configs.EnWord);

            return this;
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