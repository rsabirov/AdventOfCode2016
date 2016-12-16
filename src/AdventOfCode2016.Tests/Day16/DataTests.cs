using AdventOfCode2016.Day16;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day16
{
    public sealed class DataTests
    {
        [TestCase("1", ExpectedResult = "100")]
        [TestCase("0", ExpectedResult = "001")]
        [TestCase("11111", ExpectedResult = "11111000000")]
        [TestCase("111100001010", ExpectedResult = "1111000010100101011110000")]
        public string NextTest(string input)
        {
            var data = new Data(input);
            data.Next();

            return data.AsString();
        }

        [TestCase("110010110100", ExpectedResult = "100")]
        public string CalcChecksumTest(string input)
        {
            var data = new Data(input);
            var checksum = data.CalcChecksum();

            return Data.AsString(checksum);
        }
    }
}
