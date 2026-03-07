using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private CombatView _view;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;
        [SerializeField] private Location _location;
        [SerializeField] private CameraShaker _cameraShaker;

        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs; // Temp.

        [SerializeField] private StatCellsView _heroHealthStatView; // Temp.
        [SerializeField] private StatCellsView _heroArmorStatView; // Temp.
        [SerializeField] private StatBarView _heroExperienceStatView; // Temp.

        private CombatPresenter _presenter;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.CameraShaker = _cameraShaker;
            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsGroup, _fieldWordUnitsGroup);
            G.WordUnitFactory = new WordUnitFactory();
            G.PointsFactory = new PointsFactory();

            var deck = new Deck(_wordUnitsConfigs);
            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);
            var pointsCounter = new PointsCounter(_location.PointsAccumulationPosition);

            // ========== MVP ==========

            var model = new CombatModel(
                discardPoints: 3, 
                drawPoints: 5,
                maxAvailableWordsOnFieldCount: 5,
                maxHandCapacity: 30,
                deck: deck,
                handWordUnitsGroup: _handWordUnitsGroup,
                fieldWordUnitsGroup: _fieldWordUnitsGroup,
                grammarValidator: grammarValidator,
                pointsCounter: pointsCounter,
                location: _location);
            _presenter = new CombatPresenter(_view, model);

            // ========== Hero Stats ==========

            var heroHealth = new Health(5, 5);
            var heroArmor = new Armor(5, 5);
            var heroExperience = new Experience(0, 100);

            _heroHealthStatView.Init(heroHealth);
            _heroArmorStatView.Init(heroArmor);
            _heroExperienceStatView.Init(heroExperience);

            G.HeroStats = new HeroStats(heroHealth, heroArmor, heroExperience);

            // ========== Start Game ==========

            _view.EnableControls();
            _view.PressDrawButton();

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }

        private void OnDestroy()
        {
            _presenter?.Dispose();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
                _location.Hero.TakeDamage();
        }
    }
}