using Configs;
using Gameplay;
using GameRoot;
using GrammarValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Combat
{
    public class CombatEntryPoint : SceneEntryPoint<CombatEnterParams>
    {
        [SerializeField] private WordUnit _wordUnitPrefab;
        [SerializeField] private WordUnitConfigs[] _wordUnitsConfigs;
        [SerializeField] private HandWordUnitsLayout _handWordUnitsLayout;
        [SerializeField] private FieldFlowLayout _fieldWordUnitsLayout;

        protected override IEnumerator Run(CombatEnterParams enterParams)
        {
            var isLoaded = false;

            G.WordUnitsMovementProvider = new WordUnitsMovementProvider(_handWordUnitsLayout, _fieldWordUnitsLayout);

            var wordUnits = new List<WordUnit>();
            foreach (var configs in _wordUnitsConfigs)
            {
                var newWordUnit = Instantiate(_wordUnitPrefab).SetConfigs(configs);
                wordUnits.Add(newWordUnit);
            }

            _handWordUnitsLayout.SetWordUnits(wordUnits.Select(w => w.Transform));

            var grammarValidator = new GrammarValidator(G.Configs.LexiconConfigs);

            var tokens = new Lexer(G.Configs.LexiconConfigs).Tokenize("She is workers");
            var ast = new CFGParser().Parse(tokens);
            Debug.Log(ast);

            grammarValidator.DebugSentence("I am tired.", true);
            grammarValidator.DebugSentence("You are tired.", true);
            grammarValidator.DebugSentence("He is tired.", true);
            grammarValidator.DebugSentence("She is tired.", true);
            grammarValidator.DebugSentence("We are tired.", true);
            grammarValidator.DebugSentence("They are tired.", true);

            grammarValidator.DebugSentence("I like apples.", true);
            grammarValidator.DebugSentence("You like apples.", true);
            grammarValidator.DebugSentence("We like apples.", true);
            grammarValidator.DebugSentence("They like apples.", true);
            grammarValidator.DebugSentence("He likes apples.", true);
            grammarValidator.DebugSentence("She likes apples.", true);

            grammarValidator.DebugSentence("I like an apple.", true);
            grammarValidator.DebugSentence("You like an apple.", true);
            grammarValidator.DebugSentence("We like an apple.", true);
            grammarValidator.DebugSentence("They like an apple.", true);
            grammarValidator.DebugSentence("He likes an apple.", true);
            grammarValidator.DebugSentence("She likes an apple.", true);

            grammarValidator.DebugSentence("I like the apple.", true);
            grammarValidator.DebugSentence("You like the apple.", true);
            grammarValidator.DebugSentence("We like the apple.", true);
            grammarValidator.DebugSentence("They like the apple.", true);
            grammarValidator.DebugSentence("He likes the apple.", true);
            grammarValidator.DebugSentence("She likes the apple.", true);

            grammarValidator.DebugSentence("Do I like apples?", true);
            grammarValidator.DebugSentence("Do you like apples?", true);
            grammarValidator.DebugSentence("Do we like apples?", true);
            grammarValidator.DebugSentence("Do they like apples?", true);
            grammarValidator.DebugSentence("Does he like apples?", true);
            grammarValidator.DebugSentence("Does she like apples?", true);

            grammarValidator.DebugSentence("Do I like an apple?", true);
            grammarValidator.DebugSentence("Do you like an apple?", true);
            grammarValidator.DebugSentence("Do we like an apple?", true);
            grammarValidator.DebugSentence("Do they like an apple?", true);
            grammarValidator.DebugSentence("Does he like an apple?", true);
            grammarValidator.DebugSentence("Does she like an apple?", true);

            grammarValidator.DebugSentence("Is he tired?", true);
            grammarValidator.DebugSentence("Is she tired?", true);
            grammarValidator.DebugSentence("Am I tired?", true);
            grammarValidator.DebugSentence("Are you tired?", true);
            grammarValidator.DebugSentence("Are we tired?", true);
            grammarValidator.DebugSentence("Are they tired?", true);

            grammarValidator.DebugSentence("I am a worker.", true);
            grammarValidator.DebugSentence("You are a worker.", true);
            grammarValidator.DebugSentence("He is a worker.", true);
            grammarValidator.DebugSentence("She is a worker.", true);
            grammarValidator.DebugSentence("We are workers.", true);
            grammarValidator.DebugSentence("They are workers.", true);

            grammarValidator.DebugSentence("Am I a worker?", true);
            grammarValidator.DebugSentence("Are you a worker?", true);
            grammarValidator.DebugSentence("Is he a worker?", true);
            grammarValidator.DebugSentence("Is she a worker?", true);
            grammarValidator.DebugSentence("Are we workers?", true);
            grammarValidator.DebugSentence("Are they workers?", true);

            grammarValidator.DebugSentence("The worker is tired.", true);
            grammarValidator.DebugSentence("The workers are tired.", true);
            grammarValidator.DebugSentence("Is the worker tired?", true);
            grammarValidator.DebugSentence("Are the workers tired?", true);

            grammarValidator.DebugSentence("I is tired.", false);
            grammarValidator.DebugSentence("He are tired.", false);
            grammarValidator.DebugSentence("They is tired.", false);
            grammarValidator.DebugSentence("We am tired.", false);
            grammarValidator.DebugSentence("She are tired.", false);
            grammarValidator.DebugSentence("You is tired.", false);

            grammarValidator.DebugSentence("He like apples.", false);
            grammarValidator.DebugSentence("She like apples.", false);
            grammarValidator.DebugSentence("I likes apples.", false);
            grammarValidator.DebugSentence("They likes apples.", false);
            grammarValidator.DebugSentence("We likes apples.", false);
            grammarValidator.DebugSentence("You likes apples.", false);

            grammarValidator.DebugSentence("Does he likes apples?", false);
            grammarValidator.DebugSentence("Does she likes apples?", false);
            grammarValidator.DebugSentence("Do he like apples?", false);
            grammarValidator.DebugSentence("Do she like apples?", false);
            grammarValidator.DebugSentence("Does they like apples?", false);
            grammarValidator.DebugSentence("Do we likes apples?", false);

            grammarValidator.DebugSentence("Is they tired?", false);
            grammarValidator.DebugSentence("Are he tired?", false);
            grammarValidator.DebugSentence("Am you tired?", false);
            grammarValidator.DebugSentence("Are she tired?", false);

            grammarValidator.DebugSentence("He is worker.", false);
            grammarValidator.DebugSentence("She is workers.", false);
            grammarValidator.DebugSentence("We are worker.", false);
            grammarValidator.DebugSentence("They is workers.", false);

            grammarValidator.DebugSentence("A apple is tired.", false);
            grammarValidator.DebugSentence("An worker is tired.", false);
            grammarValidator.DebugSentence("The workers is tired.", false);
            grammarValidator.DebugSentence("The worker are tired.", false);

            grammarValidator.DebugSentence("I do like apples?", false);
            grammarValidator.DebugSentence("Does he like apples.", false);
            grammarValidator.DebugSentence("Are the worker tired?", false);
            grammarValidator.DebugSentence("Is the workers tired?", false);

            grammarValidator.DebugSentence("Am tired I.", false);
            grammarValidator.DebugSentence("Are tired you.", false);
            grammarValidator.DebugSentence("Is tired he.", false);
            grammarValidator.DebugSentence("Are tired they.", false);

            grammarValidator.DebugSentence("Like I apples.", false);
            grammarValidator.DebugSentence("Likes he apples.", false);
            grammarValidator.DebugSentence("Like they apples.", false);
            grammarValidator.DebugSentence("Likes she apple.", false);

            grammarValidator.DebugSentence("Apples I like.", false);
            grammarValidator.DebugSentence("Apple he likes an.", false);
            grammarValidator.DebugSentence("The like we apple.", false);
            grammarValidator.DebugSentence("Workers are the tired.", false);

            grammarValidator.DebugSentence("Do like you apples?", false);
            grammarValidator.DebugSentence("Does like he apples?", false);
            grammarValidator.DebugSentence("Like do they apples?", false);
            grammarValidator.DebugSentence("Like does she apple?", false);

            grammarValidator.DebugSentence("Tired is she?", false);
            grammarValidator.DebugSentence("Worker a is he.", false);
            grammarValidator.DebugSentence("Are workers they tired?", false);
            grammarValidator.DebugSentence("Is worker the tired?", false);

            isLoaded = true;
            yield return new WaitUntil(() => isLoaded);
        }
    }
}