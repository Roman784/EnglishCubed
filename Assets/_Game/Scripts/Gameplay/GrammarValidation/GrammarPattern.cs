using System.Collections.Generic;
using UnityEngine;

namespace GrammarValidation
{
    public class GrammarPattern
    {
        public List<PatternElement> Elements;

        public GrammarPattern(List<PatternElement> elements)
        {
            Elements = elements;
        }

        public bool Match(List<WordData> words)
        {
            int w = 0;

            /*foreach (var element in Elements)
            {
                if (w >= words.Count)
                {
                    if (element.Optional) continue;
                    return false;
                }

                if (element.Match(words[w]))
                {
                    if (!element.Repeatable)
                        w++;
                    else
                    {
                        while (w < words.Count && element.Match(words[w]))
                            w++;
                    }
                }
                else if (!element.Optional)
                    return false;
            }*/

            return w == words.Count;
        }
    }
}