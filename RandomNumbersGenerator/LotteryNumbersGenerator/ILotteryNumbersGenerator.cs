using System.Collections.Generic;

namespace LotteryNumbersGenerator
{
    public interface ILotteryNumbersGenerator
    {
        //Minimum value, maximum value and numbers per set can be set as configurable by exposing these properties
        //int MinimumValue { get; set; }
        //int MaximumValue { get; set; }
        //int NumbersPerSet { get; set; }
        IEnumerable<GeneratedNumbersDto> GenerateNumbers(int sets, int lotteryType);
    }
}
