using Configs;
using R3;
using TMPro;
using UnityEngine;
using Utils;

namespace Gameplay
{
    [RequireComponent(typeof(WordUnitTransform))]
    public class WordUnit : MonoBehaviour
    {
        [SerializeField] private TMP_Text _wordView;
        [SerializeField] private PointerDetector _pointerDetector;

        private WordUnitConfigs _configs;
        private WordUnitTransform _transform;

        public WordUnitTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<WordUnitTransform>();

            InitBehavior();
        }

        public WordUnit SetConfigs(WordUnitConfigs configs)
        {
            _configs = configs;
            SetWord(_configs.Word.Text);

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

        private void SetWord(string word)
        {
            _wordView.text = word;
            _transform.SetContainerSize(_wordView.preferredWidth);
        }
    }
}