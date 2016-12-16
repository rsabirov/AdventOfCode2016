using AdventOfCode2016.Day15;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.Day15
{
    public sealed class DiskTests
    {
        [Test]
        public void ParseTest()
        {
            var disk = new Disk("Disc #3 has 19 positions; at time=0, it is at position 2.");
            Assert.AreEqual(3, disk.Number);
            Assert.AreEqual(2, disk.PosAtZero);
            Assert.AreEqual(19, disk.PositionsCount);
        }

        public void PositionAtTest1()
        {
            var disk = new Disk(1, 0, 2);

            Assert.AreEqual(0, disk.PosAtTime(0));
            Assert.AreEqual(1, disk.PosAtTime(1));
            Assert.AreEqual(0, disk.PosAtTime(2));
        }

        public void PositionAtTest2()
        {
            var disk = new Disk(2, 4, 5);

            Assert.AreEqual(4, disk.PosAtTime(0));
            Assert.AreEqual(0, disk.PosAtTime(1));
            Assert.AreEqual(1, disk.PosAtTime(2));
        }
    }
}