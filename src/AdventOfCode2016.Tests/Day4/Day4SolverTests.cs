using System.IO;
using AdventOfCode2016.Day4;
using AdventOfCode2016.Tests.TestData;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day4
{
    public sealed class Day4SolverTests
    {
        [Test]
        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", "aaaaa-bbb-z-y-x", 123, "abxyz", true)]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", "a-b-c-d-e-f-g-h", 987, "abcde", true)]
        [TestCase("not-a-real-room-404[oarel]", "not-a-real-room", 404, "oarel", true)]
        [TestCase("totally-real-room-200[decoy]", "totally-real-room", 200, "decoy", false)]
        public void EncryptedNameTest(string encryptedText, string name, int id, string checksum, bool isReal)
        {
            var parsed = EncryptedName.Parse(encryptedText);
            Assert.AreEqual(name, parsed.Name);
            Assert.AreEqual(id, parsed.Id);
            Assert.AreEqual(checksum, parsed.Checksum);
            Assert.AreEqual(isReal, parsed.IsReal);
        }

        [Test]
        public void DecrypedNameTest()
        {
            var p = EncryptedName.Parse("qzmt-zixmtkozy-ivhz-343[dfsae]");
            Assert.AreEqual("very encrypted name", p.DecryptedName);
        }

        [Test]
        public void DayInstructionTest()
        {
            var data = new[]
            {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "a-b-c-d-e-f-g-h-987[abcde]",
                "not-a-real-room-404[oarel]",
                "totally-real-room-200[decoy]"
            };

            var solver = new Day4Solver();
            var ans = solver.SolvePart1(data);

            Assert.AreEqual(1514, ans);
        }
        
        [Test]
        public void Day4Part1Test()
        {
            var path = TestDataHelper.GetPath("Day4.txt");
            var codes = File.ReadLines(path);
            
            var solver = new Day4Solver();
            var ans = solver.SolvePart1(codes);

            Assert.AreEqual(278221, ans);
        }

        [Test]
        public void Day4Part2Test()
        {
            var path = TestDataHelper.GetPath("Day4.txt");
            var codes = File.ReadLines(path);
            
            var solver = new Day4Solver();
            var ans = solver.SolvePart2(codes);

            Assert.AreEqual(267, ans);
        }
    }
}
