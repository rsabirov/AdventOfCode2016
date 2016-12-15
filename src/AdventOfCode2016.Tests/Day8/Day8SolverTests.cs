using System;
using System.IO;
using System.Linq;
using AdventOfCode2016.Day8;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day8
{
    public sealed class Day8SolverTests
    {
        [Test]
        public void Day8Part1InstructionTest()
        {
            var instructions = new[]
            {
                "rect 3x2",
                "rotate column x=1 by 1",
                "rotate row y=0 by 4",
                "rotate column x=1 by 1"
            };

            var solver = new Day8Solver();
            var ans = solver.Day8SolvePart1(instructions, w: 7, h: 3);

            Assert.AreEqual(6, ans);
        }

        [Test]
        public void Day8Part1Test()
        {
            var path = TestDataHelper.GetPath("Day8.txt");
            var instructions = File.ReadLines(path).ToArray();

            var solver = new Day8Solver();
            var ans = solver.Day8SolvePart1(instructions);

            Assert.AreEqual(123, ans);
        }

        [Test]
        public void Day8Part2Test()
        {
            var path = TestDataHelper.GetPath("Day8.txt");
            var instructions = File.ReadLines(path).ToArray();

            var solver = new Day8Solver();
            var matrix = solver.Day8SolvePart2(instructions);

            // writing resulting matrix to file
            var filePath = Path.GetTempFileName();
            WriteMatrixToFile(matrix, filePath);

            //HINT: for getting result checkout the file
            Console.WriteLine("Result saved in '{0}'", filePath);
        }

        private static void WriteMatrixToFile(bool[,] matrix, string fileName)
        {
            using (var file = File.OpenWrite(fileName))
            using (var writter = new StreamWriter(file))
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                        writter.Write("{0} ", matrix[j, i] ? '#' : '.');
                    writter.WriteLine();
                }
            }
        }
    }
}
