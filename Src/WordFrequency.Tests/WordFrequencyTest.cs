using NUnit.Framework;
using System.Collections.Generic;

namespace WordFrequency.Tests
{
    public class WordFrequencyTest
    {
        IWordFrequencyAnalyzer frequencyAnalyzer;

        [SetUp]
        public void Setup()
        {
            frequencyAnalyzer = new WordFrequencyAnalyzer();
        }

        [Test]
        public void CalculateHighestFrequencyTest()
        {
            var text = "The sun shines over the lake.";
            
            var result = frequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateHighestFrequencyCaseInSensitiveTest()
        {
            var text = "The sun shines over tHe lake.";

            var result = frequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateFrequencyForWordTest()
        {
            var text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful.";
            var result = frequencyAnalyzer.CalculateFrequencyForWord(text, "the");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void CalculateMostFrequentNWordsTest()
        {
            var text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful.";
            var result = frequencyAnalyzer.CalculateMostFrequentNWords(text, 3);
            

            Assert.AreEqual(5, result[0].Frequency);
            Assert.AreEqual(5, result[1].Frequency);
            Assert.AreEqual(4, result[2].Frequency);
        }
    }
}