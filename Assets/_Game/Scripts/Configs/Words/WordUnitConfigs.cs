using GrammarValidation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WordUnitConfigs",
                     menuName = "Game Configs/Words/New Word Unit Configs")]
    public class WordUnitConfigs: ScriptableObject
    {
        public WordData Word;

#if UNITY_EDITOR
        [ContextMenu("Set Up Article")]
        private void SetUpArticle()
        {
            Word.PartOfSpeech = PartOfSpeech.Article;
            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up Auxiliary Verb")]
        private void SetUpAuxiliaryVerb()
        {
            Word.PartOfSpeech = PartOfSpeech.AuxiliaryVerb;
            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up Pronoun")]
        private void SetUpPronoun()
        {
            Word.PartOfSpeech = PartOfSpeech.Pronoun;
            // Person, Number.

            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up Verb")]
        private void SetUpVerb()
        {
            Word.PartOfSpeech = PartOfSpeech.Verb;
            Word.Tense = Tense.Present;
            // VerbForm.

            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up To Be")]
        private void SetUpToBe()
        {
            Word.PartOfSpeech = PartOfSpeech.Verb;
            Word.VerbForm = VerbForm.Base;
            Word.Tense = Tense.Present;
            Word.IsLinkingVerb = true;

            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up Noun")]
        private void SetUpNoun()
        {
            Word.PartOfSpeech = PartOfSpeech.Noun;
            Word.Person = Person.Third;
            // Number, IsCountable.

            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Set Up Adjective")]
        private void SetUpAdjective()
        {
            Word.PartOfSpeech = PartOfSpeech.Adjective;
            EditorUtility.SetDirty(this);
        }
#endif
    }
}