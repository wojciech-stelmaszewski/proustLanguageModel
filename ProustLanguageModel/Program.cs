using ProustLanguageModel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProustLanguageModel
{
    class Program
    {
        private const string filename = "Data/proust_02.txt";

        static void Main(string[] args)
        {
            string line;

            var unigrams = new Dictionary<string, uint>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                foreach (var word in TextReader.GetWords(line))
                {
                    if (!SpecialSymbols.IsSpecialSymbol(word))
                    {
                        var lowercasedWord = word.ToLower();
                        if (unigrams.ContainsKey(lowercasedWord))
                        {
                            unigrams[lowercasedWord]++;
                        }
                        else
                        {
                            unigrams.Add(lowercasedWord, 1);
                        }
                    }
                }
            }

            // 100 most common words
            Console.WriteLine($"WORDS COUNT: {unigrams.Sum(x => x.Value)}");
            Console.WriteLine($"UNIQUE WORDS COUNT: {unigrams.Count()}");
            Console.WriteLine("100 MOST COMMON WORDS");
            unigrams.OrderByDescending(x => x.Value).Take(100).ForEach(unigram => Console.WriteLine($"{unigram.Key}: {unigram.Value}")).ToList();

            Console.ReadLine();
        }
    }
}
