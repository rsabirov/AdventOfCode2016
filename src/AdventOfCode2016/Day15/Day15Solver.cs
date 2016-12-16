using System.Linq;

namespace AdventOfCode2016.Day15
{
    public sealed class Day15Solver
    {
        public int Solve(string[] disksDescriptions)
        {
            var disks = disksDescriptions.Select(s => new Disk(s)).ToArray();

            for (int t = 0; t < 1000 * 1000 * 1000; t++)
            {
                if (disks.All(disk => disk.PosAtTime(t + disk.Number) == 0))
                    return t;
            }

            return 0;
        }
    }
}