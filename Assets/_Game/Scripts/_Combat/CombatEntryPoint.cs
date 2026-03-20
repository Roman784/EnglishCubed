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
            var heroArmor = new Armor(2);
            var heroExperience = new Experience(0, 100);

            _view.HeroHealthStatView.Init(heroHealth);
            _view.HeroArmorStatView.Init(heroArmor);
            _view.HeroExperienceStatView.Init(heroExperience);

            var heroStats = new Stats(heroHealth, heroArmor, heroExperience);

            // ========== Hero ==========

            _location.Hero.Init(heroStats);

            // ========== Commands ==========

            InitCommands(heroStats);

            // ========== Abilities ==========

            var abilityInventoryModel = new AbilityInventoryModel(
                allConfigs: _abilitiesConfigs);
            _abilityInventory = new AbilityInventoryPresenter(_abilityInventoryView, abilityInventoryModel);

            // ========== Start Game ==========

            _view.EnableControls();
            _view.PressDrawButton();

            Debug.Log(heroStats.ToString());

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
            G.CommandProcessor.RegisterHandler(
                new IncreaseHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new IncreaseArmorCommandHandler(heroStats.Armor));
            G.CommandProcessor.RegisterHandler(
                new RestoreHealthCommandHandler(heroStats.Health));
            G.CommandProcessor.RegisterHandler(
                new RestoreArmorCommandHandler(heroStats.Armor));
            G.CommandProcessor.RegisterHandler(
                new IncreaseVampirismCommandHandler(heroStats.GetStat(StatName.Vampirism)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseVampirismPowerCommandHandler(heroStats.GetStat(StatName.VampirismPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseExperienceMultiplierCommandHandler(heroStats.GetStat(StatName.ExperiencePower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseHandCapacityCommandHandler(heroStats.GetStat(StatName.HandCapacity)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseFieldCapacityCommandHandler(heroStats.GetStat(StatName.FieldCapacity)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseDrawsCountCommandHandler(heroStats.GetStat(StatName.DrawsCount)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseDiscardsCountCommandHandler(heroStats.GetStat(StatName.DiscardsCount)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseDeclarativeSentencePowerCommandHandler(heroStats.GetStat(StatName.DeclarativeSentencePower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseInterrogativeSentenceMultiplierCommandHandler(heroStats.GetStat(StatName.InterrogativeSentencePower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseExclamatorySentencePowerCommandHandler(heroStats.GetStat(StatName.ExclamatorySentencePower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseThreeWordsPowerCommandHandler(heroStats.GetStat(StatName.ThreeWordsPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseFourWordsPowerCommandHandler(heroStats.GetStat(StatName.FourWordsPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseFieldCapacityCommandHandler(heroStats.GetStat(StatName.FieldCapacity)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseDodgeCommandhandler(heroStats.GetStat(StatName.Dodge)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseRageAttackCommandHandler(heroStats.GetStat(StatName.Attack)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseCriticalAttackCommandHandler(heroStats.GetStat(StatName.CriticalAttack)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseCriticalAttackPowerCommandHandler(heroStats.GetStat(StatName.CriticalAttackPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseRageAttackCommandHandler(heroStats.GetStat(StatName.RageAttack)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseRageDodgeCommandHandler(heroStats.GetStat(StatName.RageDodge)));
            G.CommandProcessor.RegisterHandler(
                new IncreasePronounsPowerCommandHandler(heroStats.GetStat(StatName.PronounsPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseLinkingVerbsPowerCommandHandler(heroStats.GetStat(StatName.LinkingVerbsPower)));
            G.CommandProcessor.RegisterHandler(
                new IncreaseAdjectivesPowerCommandHandler(heroStats.GetStat(StatName.AdjectivesPower)));
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
                G.CommandProcessor.Process(new IncreaseHealthCommand(1));
        }
    }
}