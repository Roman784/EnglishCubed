using System;

namespace Gameplay
{
    public class StatModifier
    {
        public readonly string Id;
        public readonly ModifierType ModifierType;
        public readonly float Value;
        public readonly Func<float, float> СustomFormula;

        public StatModifier(ModifierType modifierType, float value = 0f, Func<float, float> сustomFormula = null)
        {
            Id = Guid.NewGuid().ToString();

            ModifierType = modifierType;
            Value = value;
            СustomFormula = сustomFormula;
        }

        public static StatModifier Flat(float value) 
            => new StatModifier(ModifierType.Flat, value);
        public static StatModifier Multiplier(float value) 
            => new StatModifier(ModifierType.Multiplier, value);
        public static StatModifier Custom(Func<float, float> formula) 
            => new StatModifier(ModifierType.Custom, 0f, formula);
    }

    public enum ModifierType
    {
        Flat,
        Multiplier,
        Custom
    }
}