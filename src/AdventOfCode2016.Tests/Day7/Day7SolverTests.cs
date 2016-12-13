using System.Diagnostics;
using System.IO;
using AdventOfCode2016.Day7;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day7
{
    public sealed class Day7SolverTests
    {
        [Test]
        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        public void Day7Part1InstructionTest(string addr, bool isTls)
        {
            var address = IpAddress.Parse(addr);

            Assert.AreEqual(isTls, address.Tls);
        }

        [Test]
        public void Day7Part1Test()
        {
            var path = TestDataHelper.GetPath("Day7.txt");
            var lines = File.ReadAllLines(path);

            var solver = new Day7Solver();
            var ans = solver.SolvePart1(lines);

            Assert.AreEqual(118, ans);
        }

        [Test]
        [TestCase("aba[bab]xyz", true)]
        [TestCase("xyx[xyx]xyx", false)]
        [TestCase("aaa[kek]eke", true)]
        [TestCase("zazbz[bzb]cdb", true)]
        public void Day7Part2InstructionTest(string addr, bool isSsl)
        {
            var address = IpAddress.Parse(addr);

            Assert.AreEqual(isSsl, address.Ssl);
        }

        [Test]
        public void Day7Part2Test()
        {
            var path = TestDataHelper.GetPath("Day7.txt");
            var lines = File.ReadAllLines(path);

            var solver = new Day7Solver();
            var ans = solver.SolvePart2(lines);

            Assert.AreEqual(260, ans);
        }
    }
}
