using AdventOfCode2016.Day16;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day16
{
    public sealed class Day16SolverTests
    {
        [Test]
        public void Day16Part1InstructionTest()
        {
            var solver = new Day16Solver();
            var ans = solver.Day16Solve("10000", 20);

            Assert.AreEqual("01100", ans);

        }

        [Test]
        public void Day16Part1Test()
        {
            var solver = new Day16Solver();
            var ans = solver.Day16Solve("11101000110010100", 272);

            Assert.AreEqual("10100101010101101", ans);
        }

        [Test]
        public void Day16Part2Test()
        {
            var solver = new Day16Solver();
            var ans = solver.Day16Solve("11101000110010100", 35651584);

            Assert.AreEqual("01100001101101001", ans);
        }
    }
}