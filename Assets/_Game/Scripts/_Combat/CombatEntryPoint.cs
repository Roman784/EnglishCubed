using Abilities;
using Commands;
using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using R3;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private CombatView _view;
        [SerializeField] private AbilityInventoryView _abilityInventoryView;
        [SerializeField] private HandWordUnitsGroup _handWordUnitsGroup;
        [SerializeField] private FieldWordUnitsGroup _fieldWordUnitsGroup;
        [SerializeField] private Location _location;
        [SerializeField] private CameraShaker _cameraShaker;

        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs; // Temp.
        [SerializeField] private AbilityConfigs[] _abilitiesConfigs; // Temp.

        private CombatPresenter _presenter;
        private AbilityInventoryPresenter _abilityInventory;

        private Stats _heroStats; // Temp.

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

            var heroHealth = new Health(3);
            var heroArmor = new Armor(0);
            var heroExperience = new Experience(0, 100);

            _view.HeroHealthStatView.Init(heroHealth);
            _view.HeroArmorStatView.Init(heroArmor);
            _view.HeroExperienceStatView.Init(heroExperience);

            _heroStats = new Stats(heroHealth, heroArmor, heroExperience);

            // ========== Hero ==========

            _location.Hero.Init(_heroStats);

            // ========== Commands ==========

            InitCommands(_heroStats);

            // ========== Abilities ==========

            var abilityInventoryModel = new AbilityInventoryModel(
                allConfigs: _abilitiesConfigs);
            _abilityInventory = new AbilityInventoryPresenter(_abilityInventoryView, abilityInventoryModel);

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

        private void InitCommands(Stats heroStats)
        {
            G.CommandProcessor = new CombatCommandProcessor();
            /*G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseArmorCommandHandler(heroStats.Armor));
            G.CommandProcessor.RegisterHandler(
                new AbilityRestoreHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new AbilityRestoreArmorCommandHandler(heroStats.Armor));*/
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseVampirismCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseVampirismPowerCommandHandler(heroStats));
            /*G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseExperiencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseHandCapacityCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFieldCapacityCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDrawsCountCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDiscardsCountCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDeclarativeSentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseInterrogativeSentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseExclamatorySentencePowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseThreeWordsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFourWordsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseFieldCapacityCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseDodgeCommandhandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseRageAttackCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseCriticalAttackCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseCriticalAttackPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseRageAttackCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseRageDodgeCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreasePronounsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseLinkingVerbsPowerCommandHandler(heroStats));
            G.CommandProcessor.RegisterHandler(
                new AbilityIncreaseAdjectivesPowerCommandHandler(heroStats));*/
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _view.DisableControls();
                var popUp = G.PopUpsProvider.OpenAbilitySelectionPopUp(_abilityInventory.GetAbilitiesForSelection());
                popUp.CloseSignal.Subscribe(_ => _view.EnableControls());
                popUp.AbilitySelectedSignal.Subscribe(abilityName =>
                {
                    _abilityInventory.AcquireAbility(abilityName);
                });
            }

            else if (Input.GetKeyDown(KeyCode.I))
                G.CommandProcessor.Process(new AbilityIncreaseHealthCommand(1));

            else if (Input.GetKeyDown(KeyCode.S))
                Debug.Log(_heroStats.ToString());
        }
    }
}