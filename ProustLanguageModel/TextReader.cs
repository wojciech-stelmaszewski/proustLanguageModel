using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProustLanguageModel
{
    public class TextReader
    {
        private const string SentencesSplittingRegex = @"(?<=[.?!])\s*(?=[A-Z])";
        private const string WordsSplittingRegex = @"((\b[^\s]+\b)((?<=\.\w).)?)";

        private const char SpecialSplittingSymbol = '@';

        public static IEnumerable<string> GetWords(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var sentences = Regex.Replace(text, SentencesSplittingRegex, SpecialSplittingSymbol.ToString()).Split(SpecialSplittingSymbol);

            foreach (var sentence in sentences)
            {
                yield return SpecialSymbols.SentenceStart;

                var words = Regex.Matches(sentence, WordsSplittingRegex);
                foreach (var word in words)
                {
                    yield return word.ToString();
                }

                yield return SpecialSymbols.SentenceEnd;
            }
        }
    }
}
