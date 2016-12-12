using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016.Day6
{
    public class Day6Solver
    {
        public string SolvePart1(string[] messages)
        {
            Debug.Assert(messages.All(m => m.Length == messages.First().Length));

            var mostFrequentCharsForEachPosition = Enumerable
                .Range(0, messages.First().Length)
                .Select(i => messages
                    .Select(message => message[i])
                    .GroupBy(c => c, (c, items) => new {Char = c, Count = items.Count()})
                    .OrderByDescending(group => group.Count)
                    .Select(group => group.Char)
                    .First()
                )
                .ToArray();

            return new string(mostFrequentCharsForEachPosition);
        }

        public string SolvePart2(string[] messages)
        {
            Debug.Assert(messages.All(m => m.Length == messages.First().Length));

            var mostFrequentCharsForEachPosition = Enumerable
                .Range(0, messages.First().Length)
                .Select(i => messages
                    .Select(message => message[i])
                    .GroupBy(c => c, (c, items) => new { Char = c, Count = items.Count() })
                    .OrderBy(group => group.Count)
                    .Select(group => group.Char)
                    .First()
                )
                .ToArray();

            return new string(mostFrequentCharsForEachPosition);
        }
    }
}