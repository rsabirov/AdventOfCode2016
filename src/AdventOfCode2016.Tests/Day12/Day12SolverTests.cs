using System.IO;
using AdventOfCode2016.Day12;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day12
{
    public sealed class Day12SolverTests
    {
        [Test]
        public void Day12Part1InstructionTest()
        {
            var path = TestDataHelper.GetPath("Day12InstructionData.txt");
            var lines = File.ReadAllLines(path);
            
            var solver = new Day12Solver();
            var ans = solver.SolvePart1(lines);

            Assert.AreEqual(42, ans);
        }

        [Test]
        public void Day12Part1Test()
        {
            var path = TestDataHelper.GetPath("Day12.txt");
            var lines = File.ReadAllLines(path);
            
            var solver = new Day12Solver();
            var ans = solver.SolvePart1(lines);

            Assert.AreEqual(318020, ans);
        }

        [Test]
        public void Day12Part2Test()
        {
            var path = TestDataHelper.GetPath("Day12.txt");
            var lines = File.ReadAllLines(path);
            
            var solver = new Day12Solver();
            var ans = solver.SolvePart2(lines);

            Assert.AreEqual(9227674, ans);
        }
    }
}