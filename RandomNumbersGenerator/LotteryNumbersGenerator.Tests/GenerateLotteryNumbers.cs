using System.Linq;
using NUnit.Framework;

namespace LotteryNumbersGenerator.Tests
{
    [TestFixture]
    public class GenerateLotteryNumbers
    {

        public LotteryNumbersGenerator objLotteryNumberGenerator;

        public GenerateLotteryNumbers()
        {
            objLotteryNumberGenerator = new LotteryNumbersGenerator();
        }

        [Test]public void DummyTest()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldGenerateRequiredSetsOfNumbers()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(3, 1);
            Assert.AreEqual(3, numberSetsReturned.Count());
        }

        [Test]
        public void ShouldGenerateNumbersWithMaxValueAsSet()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 1);
            foreach(var numberSet in numberSetsReturned)
            {
                if (numberSet.MainNumbers.Any(number => number > 49))
                {
                    Assert.Fail();
                    return;
                }

            }
            Assert.Pass();
        }

        [Test]
        public void ShouldGenerateNumbersWithMinValueAsSet()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(2, 1);
            foreach (var numberSet in numberSetsReturned)
            {
                if (numberSet.MainNumbers.Any(number => number < 1))
                {
                    Assert.Fail();
                    return;
                }

            }
            Assert.Pass();
        }

        [Test]
        public void ShouldGenerateNonRepeatingNumbers()
        {
            objLotteryNumberGenerator.LotteryType = 1;
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 1);
            foreach(var numberSet in numberSetsReturned)
            {
                if (numberSet.MainNumbers.Distinct().Count() != objLotteryNumberGenerator.GetMainNumbersCount())
                {
                    Assert.Fail();
                    return;
                }
            }
            Assert.Pass();
        }

        [Test]
        public void ShouldGenerate5MainNumbersForEuroMillion()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 1);
            Assert.AreEqual(5, numberSetsReturned.FirstOrDefault().MainNumbers.Length);
        }
        [Test]
        public void ShouldGenerate2LuckyStarsForEuroMillion()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 1);
            Assert.AreEqual(2, numberSetsReturned.FirstOrDefault().LuckyStars.Length);
        }

        [Test]
        public void ShouldGenerate6MainNumbersForLotto()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 2);
            Assert.AreEqual(6, numberSetsReturned.FirstOrDefault().MainNumbers.Length);
        }
        [Test]
        public void ShouldGenerateNoLuckyStarsForEuroMillion()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 2);
            Assert.AreEqual(0, numberSetsReturned.FirstOrDefault().LuckyStars.Length);
        }

        [Test]
        public void ShouldGenerate5MainNumbersForSetForLife()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 3);
            Assert.AreEqual(5, numberSetsReturned.FirstOrDefault().MainNumbers.Length);
        }
        [Test]
        public void ShouldGenerate1LifeBallForSetForLife()
        {
            var numberSetsReturned = objLotteryNumberGenerator.GenerateNumbers(1, 3);
            Assert.AreEqual(1, numberSetsReturned.FirstOrDefault().LuckyStars.Length);
        }

    }
}
