using System.IO;
using System.Linq;
using AdventOfCode2016.Day21;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day21
{
    public sealed class Day21SolverTests
    {
        [Test]
        public void Day21Part1InstructionTest()
        {
            var path = TestDataHelper.GetPath("Day21InstructionData.txt");
            var commands = File.ReadLines(path).ToArray();

            var solver = new Day21Solver();
            var ans = solver.SolvePart1("abcde", commands);

            Assert.AreEqual("decab", ans);
        }

        [Test]
        public void Day21Part1Test()
        {
            var path = TestDataHelper.GetPath("Day21.txt");
            var commands = File.ReadLines(path).ToArray();

            var solver = new Day21Solver();
            var ans = solver.SolvePart1("abcdefgh", commands);

            Assert.AreEqual("ghfacdbe", ans);
        }
        [Test]
        public void Day21Part2InstructionTest()
        {
            var path = TestDataHelper.GetPath("Day21InstructionData.txt");
            var commands = File.ReadLines(path).ToArray();

            var solver = new Day21Solver();
            var ans = solver.SolvePart2("decab", commands);

            Assert.AreEqual("abcde", ans);
        }

        [Test]
        public void Day21Part2Test()
        {
            var path = TestDataHelper.GetPath("Day21.txt");
            var commands = File.ReadLines(path).ToArray();

            var solver = new Day21Solver();
            var ans = solver.SolvePart2("fbgdceah", commands);

            Assert.AreEqual("fhgcdaeb", ans);
        }
    }
}