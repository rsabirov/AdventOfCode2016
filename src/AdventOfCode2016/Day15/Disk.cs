using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Day15
{
    public sealed class Disk
    {
        private readonly Regex _regex = new Regex("Disc #(?<number>\\d+) has (?<positionsCount>\\d+) positions; at time=0, it is at position (?<positionAtZero>\\d+).");
        public int Number { get; }
        public int PosAtZero { get; }
        public int PositionsCount { get; }

        public Disk(string description)
        {
            var match = _regex.Match(description);
            Debug.Assert(match.Success);
            Number = int.Parse(match.Groups["number"].Value);
            PositionsCount = int.Parse(match.Groups["positionsCount"].Value);
            PosAtZero = int.Parse(match.Groups["positionAtZero"].Value);
        }

        public Disk(int number, int posAtZero, int positionsCount)
        {
            Number = number;
            PosAtZero = posAtZero;
            PositionsCount = positionsCount;
        }

        public int PosAtTime(int t)
        {
            var normilized = (t + PosAtZero) % PositionsCount;
            return normilized;
        }
    }
}