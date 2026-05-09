using Abilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Utils
{
    public static class EnumExtensions
    {
        public static int Number(this Enum en)
        {
            var values = Enum.GetValues(en.GetType());
            return Array.IndexOf(values, en) + 1;
        }
    }
}