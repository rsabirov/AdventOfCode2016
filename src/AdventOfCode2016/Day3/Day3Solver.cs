using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day3
{
    public sealed class Day3Solver
    {
        public int GetAnswer(IEnumerable<Triple> triples)
        {
            return triples.Count(t => t.CanCreateTriangle);
        }
    }
}
