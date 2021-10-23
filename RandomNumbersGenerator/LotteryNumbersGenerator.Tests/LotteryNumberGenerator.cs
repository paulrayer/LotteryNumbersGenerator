using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace LotteryNumbersGenerator_Tests
{
    public class LotteryNumberGenerator
    {
        public int MinimumValue;
        public int MaximumValue;
        public int NumbersPerSet;

        public LotteryNumberGenerator()
        {
            MinimumValue = Convert.ToInt32(ConfigurationManager.AppSettings["MinimumValue"]);
            MaximumValue = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumValue"]) + 1;
            NumbersPerSet = Convert.ToInt32(ConfigurationManager.AppSettings["NumbersPerSet"]);
        }
        public List<int[]> GenerateNumbers(int sets)
        {
            var numbers = new List<int[]>();
            
            for(var i=0; i<sets; i++)
            {
                numbers.Add(GenerateNumberSet());
            }
            
            return numbers;
        }

        private int[] GenerateNumberSet()
        {
            var randomNumberGenerator = new Random();
            var numberSet = new int[NumbersPerSet];
            var i = 0;
            while (i < NumbersPerSet)
            {
                var newNumber = randomNumberGenerator.Next(MinimumValue, MaximumValue);
                if (!numberSet.Any(n => n == newNumber))
                {
                    numberSet[i] = newNumber;
                    i++;
                }
            }

            return numberSet;

        }
    }
}