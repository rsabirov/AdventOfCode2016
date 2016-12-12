using System.IO;
using System.Linq;
using AdventOfCode2016.Day2;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AdventOfCode2016.Tests.Day2
{
    [TestFixture]
    public class Day2SolverTests
    {
        [Test]
        public void Day2Part1Test()
        {
            var layout = Layout.CreateFromArray(new[,]
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            });

            var instructions = new[]
            {
                "ULL",
                "RRDDD",
                "LURDL",
                "UUUUD"
            };

            var solver = new Day2Solver(layout);
            var actual = solver.GetAnswer(instructions, new Position(1, 1));

            Assert.AreEqual("1985", actual);
        }

        [Test]
        public void Day2Part2Test()
        {
            var layout = Layout.CreateFromArray(new[,]
            {
                  {'0', '0', '1', '0', '0'},
                  {'0', '2', '3', '4', '0'},
                  {'5', '6', '7', '8', '9'},
                  {'0', 'A', 'B', 'C', '0'},
                  {'0', '0', 'F', '0', '0'}

            });

            var path = TestDataHelper.GetPath("Day2.txt");
            var instructions = File.ReadLines(path).ToArray();

            var solver = new Day2Solver(layout);
            var actual = solver.GetAnswer(instructions, new Position(2, 0));

            Assert.AreEqual("8CB23", actual);
        }
    }
}