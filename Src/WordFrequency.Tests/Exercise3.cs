using System.Collections.Generic;
using NUnit.Framework;

namespace TenergyCodingSkills
{
    [TestFixture]
    public class Exercise3
    {
        private static Dictionary<char, int> _points = new Dictionary<char, int>()
        {
            {'a', 1}, {'e', 1}, {'i', 1}, {'o', 1}, {'u', 1},
            {'l', 1}, {'n', 1}, {'r', 1}, {'s', 1}, {'t', 1},
            {'d', 2}, {'g', 2},
            {'b', 3}, {'c', 3}, {'m', 3}, {'p', 3},
            {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4}, {'y', 4},
            {'k', 5},
            {'j', 8}, {'x', 8},
            {'q',10}, {'z',10},
        };

        private List<string> FilterInputs(int n, List<string> inputs)
        {
            var dictionary = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var word = inputs[i];
                if (word.Length <= 7)
                    dictionary.Add(word.ToLowerInvariant());
            }

            return dictionary;
        }

        private Dictionary<char, int> GetHashTable(string words)
        {   
            var hash = new Dictionary<char, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (hash.ContainsKey(words[i]))
                {
                    hash[words[i]] = hash[words[i]] + 1;
                }
                else
                {
                    hash.Add(words[i], 1);
                }
            }
            return hash;
        }

        private int GetScore(string input, Dictionary<char, int> letterHash)
        {
            int totalScore = 0;
            var wordHash = GetHashTable(input);

            foreach (var word in wordHash)
            {
                if (!letterHash.ContainsKey(word.Key))
                {
                    return -1;
                }

                totalScore += wordHash[word.Key] * _points[word.Key];
            }

            return totalScore;
        }

        private string GetMaximumScoredWord(List<string> wordDictionary, Dictionary<char, int> lettersHash)
        {
            var maxScore = -1;
            string maxScoredWord = null;

            for (var i = 0; i < wordDictionary.Count; i++)
            {
                var score = GetScore(wordDictionary[i], lettersHash);
                if (maxScore < score)
                {
                    maxScore = score;
                    maxScoredWord = wordDictionary[i];
                }
            }
            return maxScoredWord;
        }


        [Test]
        public void TestCase1()
        {
            var n = 5;
            var availableLetters = "hicquwh";

            var inputs = new List<string>
            {
                "because",
                "first",
                "these",
                "could",
                "which"
            };

            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("which", result);
        }

        [Test]
        public void TestCase2()
        {
            var n = 10;
            var availableLetters = "sopitez";

            var inputs = new List<string>
            {
                "some",
                "first",
                "potsie",
                "day",
                "could ",
                "postie",
                "from",
                "have",
                "back",
                "this"
            };



            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("potsie", result);
        }

        [Test]
        public void TestCase3()
        {
            var n = 10;
            var availableLetters = "tsropwe";

            var inputs = new List<string>
            {
                "after",
                "repots",
                "user",
                "powers",
                "these",
                "time",
                "know",
                "from",
                "could",
                "people"
            };



            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("powers", result);
        }

        [Test]
        public void TestCase4()
        {
            var n = 10;
            var availableLetters = "arwtsre";

            var inputs = new List<string>
            {
                "arrest",
                "rarest",
                "raster",
                "raters",
                "sartre",
                "starer",
                "waster",
                "waters",
                "wrest",
                "wrase"
            };



            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("waster", result);
        }

        [Test]
        public void TestCase5()
        {
            var n = 5;
            var availableLetters = "etiewrn";

            var inputs = new List<string>
            {
                "entire",
                "tween",
                "soft",
                "would",
                "test"
            };



            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("tween", result);
        }

        [Test]
        public void TestCase6()
        {
            var n = 5;
            var availableLetters = "qzaeiou";

            var inputs = new List<string>
            {
                "qzyoq",
                "azejuy",
                "kqjsdh",
                "aeiou",
                "qsjkdh"
            };



            List<string> wordDictionary = FilterInputs(n, inputs);
            var letterHash = GetHashTable(availableLetters);

            var result = GetMaximumScoredWord(wordDictionary, letterHash);

            Assert.AreEqual("aeiou", result);
        }
    }
}