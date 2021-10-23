using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryNumbersGenerator
{
    public class LotteryNumbersGenerator : ILotteryNumbersGenerator
    {
        //public int MinimumValue { get; set; }
        //public int MaximumValue { get; set; }
        //public int NumbersPerSet { get; set; }

        private int MinimumValue;
        private int MaximumValue;
        private int NumbersPerSet;
        public int LotteryType;

        public Random randomNumberGenerator = new Random();

        public IEnumerable<GeneratedNumbersDto> GenerateNumbers(int sets, int lotteryType)
        {
            MinimumValue = Settings.Default.MinimumValue;
            MaximumValue = Settings.Default.MaximumValue + 1;
            NumbersPerSet = Settings.Default.NumbersPerSet;
            LotteryType = lotteryType;

            var returnValues = new List<GeneratedNumbersDto>();

            //var numbers = new List<int[]>();
            
            for(var i=0; i<sets; i++)
            {
                returnValues.Add(GenerateNumberSet());
            }
            
            return returnValues.AsEnumerable();
        }

        public int GetMainNumbersCount()
        {
            return LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.Lotto) ? 6 : 5;
        }
        public int GetLuckyStarNumbersCount()
        {
            return (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.EuroMillion)) ? 2 :
                (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.SetForLife) ||
                LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.LottolandCash4Life)) ? 1 : 
                0;
        }
        private int GetMaxNumberForMainNumbers()
        {
            return (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.EuroMillion)) ? 50 :
                (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.Lotto)) ? 59 :
                (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.LottolandCash4Life)) ? 60
                : 47;
        }

        private int GetMaxNumberForLuckyStars()
        {
            return (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.EuroMillion)) ? 12 :
                (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.SetForLife)) ? 10 :
                (LotteryType == Convert.ToInt32(LotteryNumberGeneratorEnums.LotteryTypes.LottolandCash4Life)) ? 4 :
                0;
        }

        private GeneratedNumbersDto GenerateNumberSet()
        {
            var countOfMainNumbers = GetMainNumbersCount();
            var maxNumber = GetMaxNumberForMainNumbers();
            var luckStars = GetMaxNumberForLuckyStars();
            var countOfLuckyStars = GetLuckyStarNumbersCount();

            var objGeneratedNumbersDto = new GeneratedNumbersDto
            {
                MainNumbers = GetRandomNumbers(countOfMainNumbers, maxNumber),
                LuckyStars = GetRandomNumbers(countOfLuckyStars, luckStars)
            };

            return objGeneratedNumbersDto;
        }

        private int[] GetRandomNumbers(int countOfNumbers, int MaxNumber)
        {
            var numberSet = new int[countOfNumbers];
            var i = 0;
            while (i < countOfNumbers)
            {
                var newNumber = randomNumberGenerator.Next(MinimumValue + i, MaxNumber);
                if (!numberSet.Any(n => n == newNumber))
                {
                    numberSet[i] = newNumber;
                    i++;
                }
            }

            return numberSet.OrderBy(o => o).ToArray();
        }
    }
}