using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day4
{
    public sealed class Day4Solver
    {
        public int SolvePart1(IEnumerable<string> codes)
        {
            var result = codes.Select(EncryptedName.Parse)
                .Where(name => name.IsReal)
                .Sum(name => name.Id);

            return result;
        }

        public int SolvePart2(IEnumerable<string> codes)
        {
            var result = codes.Select(EncryptedName.Parse)
                .Where(name => name.DecryptedName.Contains("north"));

            return result.Single().Id;
        }
    }
}
