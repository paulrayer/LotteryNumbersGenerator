using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using NUnit.Framework;

namespace LotteryNumbersWriter.Tests
{
    [TestFixture]
    public class WriteLotteryNumbers
    {
        [Test]
        public void ShouldWriteNumbersToFile()
        {
            var dataToWrite = new List<int[]> { new int[] { 1, 2, 3, 4, 5, 6 } };
            var filePath = @"C:\LotteryNumbersWriter\in.txt";

            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(filePath, new MockFileData("1"));

            var objLotteryNumbersWriter = new LotteryNumbersWriter(mockFileSystem);

            objLotteryNumbersWriter.WriteToFile(dataToWrite, filePath);

            var result = objLotteryNumbersWriter.CheckFileContent(filePath, System.DateTime.Now.ToShortDateString());

            Assert.AreEqual(true, result);

        }
    }
}
