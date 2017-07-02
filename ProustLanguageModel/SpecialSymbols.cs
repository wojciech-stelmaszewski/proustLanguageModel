using System;

namespace ProustLanguageModel
{
    public static class SpecialSymbols
    {
        public const string SentenceStart = "<SENTENCE>";
        public const string SentenceEnd = "</SENTENCE>";

        public const string UnknownWord = "<UNKNOWN_WORD/>";

        public static bool IsSpecialSymbol(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text == SentenceStart) return true;
            if (text == SentenceEnd) return true;
            if (text == UnknownWord) return true;

            return false;
        }
    }
}
