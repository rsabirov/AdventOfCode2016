using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016.Day3
{
    public class Triple
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }

        public bool CanCreateTriangle
        {
            get { return A + B > C && A + C > B && B + C > A; }
        }

        public Triple(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static Triple Parse(string s)
        {
            var parts = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(parts.Length == 3);
            var numbers = parts.Select(int.Parse).ToArray();

            return new Triple(numbers[0], numbers[1], numbers[2]);
        }
    }
}
