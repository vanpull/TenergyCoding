using System.Collections.Generic;
using NUnit.Framework;
using System;
namespace WordFrequency.Tests
{
    [TestFixture]
    public class Exercise1
    {
        private int CalculateHeistTime(int robbers, int vaults, List<string> inputs)
        {
            int[] time = new int[robbers];

            for (int i = 0; i < vaults; i++)
            {
                string[] line = inputs[i].Split();
                int C = int.Parse(line[0]);
                int N = int.Parse(line[1]);

                
                int combinations = (int)(Math.Pow(10, N) * Math.Pow(5, C - N));
                time[0] += combinations;
                Array.Sort(time);
                
               
            }

            return time[robbers - 1];
        }

        [Test]
        public void TestCase1()
        {
            var r = 1;
            var v = 1;
            var inputs = new List<string> { "3 1" };


            var result = CalculateHeistTime(r, v, inputs); //put here your final answer

            Assert.AreEqual(250, result);
        }

        [Test]
        public void TestCase2()
        {
            var r = 4;
            var v = 4;
            var inputs = new List<string>
            {
                "3 2",
                "4 1",
                "7 6",
                "7 1"
            };

            
            var result = CalculateHeistTime(r, v, inputs); //put here your final answer

            Assert.AreEqual(5000000, result);
        }
        
        [Test]
        public void TestCase3()
        {
            var r = 2;
            var v = 4;
            var inputs = new List<string>
            {
                "3 1",
                "3 2",
                "4 0",
                "4 0"
            };

            
            var result = CalculateHeistTime(r, v, inputs); //put here your final answer

            Assert.AreEqual(1125, result);
        }

        [Test]
        public void TestCase4()
        {
            var r = 5;
            var v = 20;
            var inputs = new List<string>
            {
                "6 3",
                "7 1",
                "4 4",
                "8 4",
                "3 0",
                "4 3",
                "8 1",
                "3 3",
                "5 5",
                "7 6",
                "6 2",
                "5 3",
                "5 4",
                "7 0",
                "7 0",
                "8 4",
                "6 0",
                "6 5",
                "3 2",
                "4 2"
            };

            
            var result = CalculateHeistTime(r, v, inputs); //put here your final answer

            Assert.AreEqual(6515625, result);
        }
    }
}