using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Text;

namespace LotteryNumbersWriter
{
    public class LotteryNumbersWriter : ILotteryNumbersWriter
    {
        private readonly IFileSystem _fileSystem;
        public LotteryNumbersWriter() : this(new FileSystem()) { }

        public LotteryNumbersWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void WriteToFile(List<int[]> numberSets, string filePath)
        {
            var stringToWrite = new StringBuilder();
            foreach (var set in numberSets)
            {
                stringToWrite.Append(System.DateTime.Now.ToShortDateString());
                stringToWrite.Append("\t");

                foreach (var number in set)
                {
                    stringToWrite.Append(number.ToString() + "\t");
                }
                stringToWrite.Append("\n");
            }

            using (StreamWriter sw = _fileSystem.File.CreateText(filePath))
            {
                sw.Write(stringToWrite);
            }
        }

        public bool CheckFileContent(string filePath, string contentToCheck)
        {
            using (StreamReader sr = _fileSystem.File.OpenText(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains(contentToCheck))
                        return true;
                }
            }

            return false;
        }

    }
}