using AdventOfCode2016.Day13;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day13
{
    public sealed class Day13SolverTests
    {
        [Test]
        public void Day13Part1InstructionTest()
        {
            var solver = new Day13Solver();
            var ans = solver.SolvePart1(10, new Location(1, 1), new Location(7, 4));

            Assert.AreEqual(11, ans);
        }

        [Test]
        public void Day13Part1Test()
        {
            var solver = new Day13Solver();
            var ans = solver.SolvePart1(1364, new Location(1, 1), new Location(31, 39));

            Assert.AreEqual(86, ans);
        }

        [Test]
        public void Day13Part2Test()
        {
            var solver = new Day13Solver();
            var ans = solver.SolvePart2(1364, new Location(1, 1), 50);

            Assert.AreEqual(127, ans);
        }
    }
}
