using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFrequency
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        private char[] specialChars = new char[] { '.', '?', '!', ' ', ';', ':', ',' };

        public int CalculateFrequencyForWord(string text, string word)
        {
            string[] words = text.Split(specialChars, StringSplitOptions.RemoveEmptyEntries);
            var query = from w in words
                        where w.ToLowerInvariant() == word.ToLowerInvariant()
                        select w;
            return query.Count();
        }

        public int CalculateHighestFrequency(string text)
        {
            var wordFrequencies = AnalyzeWordFrequency(text);
            var sortedWords = wordFrequencies.OrderByDescending(kvp => kvp.Value).FirstOrDefault();
            return sortedWords.Value;
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            List<IWordFrequency> mostFrequentWords = new List<IWordFrequency>();

            var wordFrequencies = AnalyzeWordFrequency(text);
            var sortedWords = wordFrequencies.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).Take(n).ToList();
            foreach (var word in sortedWords)
            {
                mostFrequentWords.Add(new WordFrequency(word.Key.ToLowerInvariant(), word.Value));
            }

            return mostFrequentWords;
        }

        private SortedDictionary<string, int> AnalyzeWordFrequency(string sourceText)
        {
            SortedDictionary<string, int> frequencyDictionary = new SortedDictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            string[] words = sourceText.Split(specialChars, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (frequencyDictionary.ContainsKey(words[i]))
                {
                    frequencyDictionary[words[i]] = frequencyDictionary[words[i]] + 1;
                }
                else
                {
                    frequencyDictionary.Add(words[i], 1);
                }
            }

            return frequencyDictionary;
        }
    }
}
