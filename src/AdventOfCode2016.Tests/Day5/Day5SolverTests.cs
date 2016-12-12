using AdventOfCode2016.Day5;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day5
{
    public sealed class Day5SolverTests
    {
        [Test]
        public void Day5Part1InstructionTest()
        {
            var solver = new Day5Solver();
            var ans = solver.SolvePart1("abc");

            Assert.AreEqual("18f47a30", ans);
        }

        [Test]
        public void Day5Part1Test()
        {
            var solver = new Day5Solver();
            var ans = solver.SolvePart1("uqwqemis");

            Assert.AreEqual("1a3099aa", ans);
        }

        [Test]
        public void Day5Part2InstructionTest()
        {
            var solver = new Day5Solver();
            var ans = solver.SolvePart2("abc");

            Assert.AreEqual("05ace8e3", ans);
        }

        [Test]
        public void Day5Part2Test()
        {
            var solver = new Day5Solver();
            var ans = solver.SolvePart2("uqwqemis");

            Assert.AreEqual("694190cd", ans);
        }
    }
}