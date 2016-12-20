using AdventOfCode2016.Day19;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day19
{
    public class Day19SolverTests
    {
        [Test]
        public void Day19Part1InstructionTest()
        {
            var solver = new Day19Solver();
            var ans = solver.SolvePart1(5);
            
            Assert.AreEqual(3, ans);
        }

        [Test]
        public void Day19Part1Test()
        {
            var solver = new Day19Solver();
            var ans = solver.SolvePart1(3014387);
            
            Assert.AreEqual(1834471, ans);
        }

        [Test]
        public void Day19Part2InstructionTest()
        {
            var solver = new Day19Solver();
            var ans = solver.SolvePart2(5);
            
            Assert.AreEqual(2, ans);
        }

        [Test]
        public void Day19Part2Test()
        {
            var solver = new Day19Solver();
            var ans = solver.SolvePart2(3014387);
            
            Assert.AreEqual(1420064, ans);
        }
    }
}
