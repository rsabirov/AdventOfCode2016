using System.IO;
using System.Linq;
using AdventOfCode2016.Day6;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day6
{
    public class Day6SolverTests
    {
        [Test]
        public void Day6Part1InstructionTest()
        {
            var path = TestDataHelper.GetPath("Day6InstructionData.txt");
            var messages = File.ReadLines(path).ToArray();

            var solver = new Day6Solver();
            var ans = solver.SolvePart1(messages);

            Assert.AreEqual("easter", ans);
        }

        [Test]
        public void Day6Part1Test()
        {
            var path = TestDataHelper.GetPath("Day6.txt");
            var messages = File.ReadLines(path).ToArray();

            var solver = new Day6Solver();
            var ans = solver.SolvePart1(messages);

            Assert.AreEqual("dzqckwsd", ans);
        }

        [Test]
        public void Day6Part2InstructionTest()
        {
            var path = TestDataHelper.GetPath("Day6InstructionData.txt");
            var messages = File.ReadLines(path).ToArray();

            var solver = new Day6Solver();
            var ans = solver.SolvePart2(messages);

            Assert.AreEqual("advent", ans);
        }

        [Test]
        public void Day6Part2Test()
        {
            var path = TestDataHelper.GetPath("Day6.txt");
            var messages = File.ReadLines(path).ToArray();

            var solver = new Day6Solver();
            var ans = solver.SolvePart2(messages);

            Assert.AreEqual("lragovly", ans);
        }
    }
}