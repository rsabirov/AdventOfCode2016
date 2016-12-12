using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2016.Day3;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day3
{
    public sealed class Day3SolverTests
    {
        [Test]
        public void Day3Part1Test()
        {
            var path = TestDataHelper.GetPath("Day3.txt");
            var triples = File.ReadLines(path)
                .Select(Triple.Parse)
                .ToArray();

            var solver = new Day3Solver();
            var actual = solver.GetAnswer(triples);

            Assert.AreEqual(917, actual);
        }


        [Test]
        public void Day3Part2Test()
        {
            var path = TestDataHelper.GetPath("Day3.txt");
            var allNumbers = File.ReadLines(path)
                .Select(s => s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(strings => strings.Select(int.Parse).ToArray())
                .ToArray();

            Assert.IsTrue(allNumbers.Length % 3 == 0);

            var triples = new List<Triple>();
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < allNumbers.Length; row += 3)
                {
                    var triple = new Triple(
                        allNumbers[row][col], allNumbers[row + 1][col], allNumbers[row + 2][col]);

                    triples.Add(triple);
                }
            }

            var solver = new Day3Solver();
            var actual = solver.GetAnswer(triples);

            Assert.AreEqual(1649, actual);
        }
    }
}