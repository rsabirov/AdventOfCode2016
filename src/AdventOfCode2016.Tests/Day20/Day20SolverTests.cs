using System.IO;
using AdventOfCode2016.Day20;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day20
{
    public sealed class Day20SolverTests
    {
        [Test]
        public void Day20Part1InstructionTest()
        {
            var rules = new string[]
            {
                "5-8",
                "0-2",
                "4-7",
                "62-65",
            };

            var solver = new Day20Solver();
            var ans = solver.SolvePart1(rules);

            Assert.AreEqual(3, ans);
        }

        [Test]
        public void Day20Part1Test()
        {
            var path = TestDataHelper.GetPath("Day20.txt");
            var rules = File.ReadAllLines(path);

            var solver = new Day20Solver();
            var ans = solver.SolvePart1(rules);

            Assert.AreEqual(4793564, ans);
        }

        [Test]
        public void Day20Part2Test()
        {
            var path = TestDataHelper.GetPath("Day20.txt");
            var rules = File.ReadAllLines(path);

            var solver = new Day20Solver();
            var ans = solver.SolvePart2(rules);

            Assert.AreEqual(2323, ans);
        }

        [TestCase("1-2", ExpectedResult = 0)]
        [TestCase("1-200", ExpectedResult = 0)]
        [TestCase("0-3", ExpectedResult = 4)]
        [TestCase("0-63", ExpectedResult = 64)]
        [TestCase("0-64", ExpectedResult = 65)]
        [TestCase("0-129", ExpectedResult = 130)]
        public int Day20Part1AddtitionalTest(string rule)
        {
            var rules = new[] { rule };

            var solver = new Day20Solver();
            var ans = solver.SolvePart1(rules);

            return ans;
        }

        //[TestCase("0-3", ExpectedResult = 4294967296UL - 4)]
        //[TestCase("0-63", ExpectedResult = 4294967296UL - 64)]
        //[TestCase("0-4294967295", ExpectedResult = 0)]
        //[TestCase("0-4294967293", ExpectedResult = 2)]
        //[TestCase("2-4294967295", ExpectedResult = 2)]
        //public ulong Day20Part2AddtitionalTest(string rule)
        //{
        //    var rules = new[] { rule };

        //    var solver = new Day20Solver();
        //    var ans = solver.SolvePart2(rules);

        //    return ans;
        //}
    }
}
