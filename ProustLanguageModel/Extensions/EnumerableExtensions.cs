using System;
using System.Collections.Generic;

namespace ProustLanguageModel.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
                yield return element;
            }
        }
    }
}
