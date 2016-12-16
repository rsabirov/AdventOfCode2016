using AdventOfCode2016.Day15;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day15
{
    public sealed class Day15SolverTests
    {
        [Test]
        public void Day15Part1InstructionTest()
        {
            var disksDescriptions = new[]
            {
                "Disc #1 has 5 positions; at time=0, it is at position 4.",
                "Disc #2 has 2 positions; at time=0, it is at position 1."
            };
            var solver = new Day15Solver();
            var ans = solver.Solve(disksDescriptions);

            Assert.AreEqual(5, ans);
        }

        [Test]
        public void Day15Part1Test()
        {
            var disksDescriptions = new[]
            {
                "Disc #1 has 17 positions; at time=0, it is at position 1.",
                "Disc #2 has 7 positions; at time=0, it is at position 0.",
                "Disc #3 has 19 positions; at time=0, it is at position 2.",
                "Disc #4 has 5 positions; at time=0, it is at position 0.",
                "Disc #5 has 3 positions; at time=0, it is at position 0.",
                "Disc #6 has 13 positions; at time=0, it is at position 5."
            };
            var solver = new Day15Solver();
            var ans = solver.Solve(disksDescriptions);

            Assert.AreEqual(317371, ans);
        }

        [Test]
        public void Day15Part2Test()
        {
            var disksDescriptions = new[]
            {
                "Disc #1 has 17 positions; at time=0, it is at position 1.",
                "Disc #2 has 7 positions; at time=0, it is at position 0.",
                "Disc #3 has 19 positions; at time=0, it is at position 2.",
                "Disc #4 has 5 positions; at time=0, it is at position 0.",
                "Disc #5 has 3 positions; at time=0, it is at position 0.",
                "Disc #6 has 13 positions; at time=0, it is at position 5.",
                "Disc #7 has 11 positions; at time=0, it is at position 0."
            };
            var solver = new Day15Solver();
            var ans = solver.Solve(disksDescriptions);

            Assert.AreEqual(2080951, ans);
        }


    }
}