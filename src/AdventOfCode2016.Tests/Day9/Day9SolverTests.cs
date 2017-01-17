using System.IO;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;
using AdventOfCode2016.Day9;

namespace AdventOfCode2016.Tests.Day9
{
    public sealed class Day9SolverTests
    {
        [Test]
        public void Day9Part1InstructionTest()
        {
            var solver = new Day9Solver();
            var compressedData = "ADVENTA(1x5)BC(3x3)XYZA(2x2)BCD(2x2)EFG(6x1)(1x3)AX(8x2)(3x3)ABCY";
            var ans = solver.Day9SolvePart1(compressedData);

            Assert.AreEqual(57, ans);
        }

        [Test]
        public void Day9Part1Test()
        {
            var path = TestDataHelper.GetPath("Day9.txt");
            var compressedData = File.ReadAllText(path);

            var solver = new Day9Solver();
            var ans = solver.Day9SolvePart1(compressedData);

            Assert.AreEqual(102239, ans);
        }

        [TestCase("ADVENT", ExpectedResult = 6)]
        [TestCase("A(1x5)BC", ExpectedResult = 7)]
        [TestCase("(3x3)XYZ", ExpectedResult = 9)]
        [TestCase("A(2x2)BCD(2x2)EFG", ExpectedResult = 11)]
        [TestCase("(6x1)(1x3)A", ExpectedResult = 3)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 20)]
        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", ExpectedResult = 241920)]
        [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", ExpectedResult = 445)]
        public long Day9Part2InstructionTest(string compressedData)
        {
            var solver = new Day9Solver();
            return solver.Day9SolvePart2(compressedData);
        }

        [Test]
        public void Day9Part2Test()
        {
            var path = TestDataHelper.GetPath("Day9.txt");
            var compressedData = File.ReadAllText(path);

            var solver = new Day9Solver();
            var ans = solver.Day9SolvePart2(compressedData);

            Assert.AreEqual(10780403063, ans);
        }
    }
}