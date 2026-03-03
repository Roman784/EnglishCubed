using Configs;
using DG.Tweening;
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

        [Space]

        [SerializeField] private WordUnitBackplate _backplatePrefab;

        [Space]

        [SerializeField] private Transform _pointsSpawnPoint;

        private WordUnitConfigs _configs;
        private WordUnitTransform _transform;

        public WordUnitTransform Transform => _transform;
        public WordUnitBackplate BackplatePrefab => _backplatePrefab;
        public int Points => _configs.Points;
        public Vector2 PointsSpawnPosition => _pointsSpawnPoint.position;

        public string GetWordText() => _configs?.Word.Text ?? "";

        private void Awake()
        {
            _transform = GetComponent<WordUnitTransform>();

            InitBehavior();
        }

        public WordUnit SetConfigs(WordUnitConfigs configs)
        {
            _configs = configs;
            SetWordText(_configs.Word.Text);

            return this;
        }

        public void Discard(Vector2 deckPosition)
        {
            _transform.Discard(deckPosition).OnComplete(() =>
            {
                Destroy(gameObject);
            });
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

        private void SetWordText(string text)
        {
            _wordView.text = text;
            _transform.SetContainerSize(_wordView.preferredWidth);
        }
    }
}