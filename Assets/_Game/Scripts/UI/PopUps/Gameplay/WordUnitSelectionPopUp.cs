using Abilities;
using Configs;
using DG.Tweening;
using Gameplay;
using GameRoot;
using R3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class WordUnitSelectionPopUp : PopUp
    {
        [Space]

        [SerializeField] private HandFlowLayout _containerLayout;
        [SerializeField] private CanvasGroup _refuseButtonView;
        [SerializeField] private TMP_Text _hintView;

        private List<WordUnit> _createdWords = new();

        private Subject<WordUnitConfigs> _wordSelectedSignalSubj = new();
        public Observable<WordUnitConfigs> WordSelectedSignal => _wordSelectedSignalSubj;

        public override PopUp SetInitialViewState()
        {
            base.SetInitialViewState();

            _refuseButtonView.alpha = 0f;
            _refuseButtonView.transform.localScale = new Vector2(0.5f, 0.5f);
            var hintColor = _hintView.color;
            hintColor.a = 0f;
            _hintView.color = hintColor;

            return this;
        }

        public void Open(IEnumerable<WordUnitConfigs> wordsConfigs)
        {
            if (wordsConfigs.Count() == 0)
            {
                Close();
                return;
            }

            SetInitialViewState();

            CreateWordUnits(wordsConfigs);
            Coroutines.Start(ShowElementsRoutine());

            base.Open();
        }

        public override void Close()
        {
            Tween lastWordHidden = null;
            foreach (var word in _createdWords)
            {
                lastWordHidden = word.Transform.Hide();
            }

            if (lastWordHidden != null)
                lastWordHidden.OnComplete(() => base.Close());
            else
                base.Close();
        }

        public void Refuse()
        {
            Close();
        }

        private void CreateWordUnits(IEnumerable<WordUnitConfigs> wordUnitsConfigs)
        {
            _createdWords = new List<WordUnit>();
            foreach (var configs in wordUnitsConfigs)
            {
                _createdWords.Add(CreateWordUnit(configs));
            }
            _containerLayout.SetInitialElements(_createdWords.Select(w => w.Transform), true);
        }

        private WordUnit CreateWordUnit(WordUnitConfigs configs)
        {
            var createWord = G.WordUnitFactory.Create(configs, transform.position);
            createWord.Transform.Show();
            createWord.transform.SetParent(_containerLayout.Container, false);

            createWord.PointerDetector.OnPointerClickSignal.Subscribe(_ => SelectWord(configs));

            return createWord;
        }

        private IEnumerator ShowElementsRoutine()
        {
            yield return new WaitForSeconds(0.35f);

            ShowRefuseButtonView();
            ShowHintView();
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

        private void SelectWord(WordUnitConfigs configs)
        {
            _wordSelectedSignalSubj.OnNext(configs);
            _wordSelectedSignalSubj.OnCompleted();

            Close();
        }
    }
}