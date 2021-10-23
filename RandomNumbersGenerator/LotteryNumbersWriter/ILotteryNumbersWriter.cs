using System.Collections.Generic;

namespace LotteryNumbersWriter
{
    public interface ILotteryNumbersWriter
    {
        void WriteToFile(List<int[]> numberSets, string filePath);
    }
}

