using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.Day8
{
    public sealed class Day8Solver
    {
        public int Day8SolvePart1(string[] instructions, int w = 50, int h = 6)
        {
            var matrix = ExecuteInstructions(instructions, h, w);

            var result = Enumerable.Range(0, w)
                .Select(i => Enumerable.Range(0, h).Select(j => matrix[i, j] ? 1 : 0).Sum())
                .Sum();

            return result;
        }

        public bool[,] Day8SolvePart2(string[] instructions, int w = 50, int h = 6)
        {
            return ExecuteInstructions(instructions, h, w);
        }

        private static bool[,] ExecuteInstructions(string[] instructions, int h, int w)
        {
            var a = new bool[w, h];

            foreach (var instruction in instructions)
            {
                var parts = instruction.Split(' ');
                var command = parts[0];

                switch (command)
                {
                    case "rect":
                        var paramParts = parts[1].Split(new[] {"x"}, StringSplitOptions.RemoveEmptyEntries);
                        var rw = int.Parse(paramParts[0]);
                        var rh = int.Parse(paramParts[1]);

                        for (int i = 0; i < Math.Min(rw, w); i++)
                        for (int j = 0; j < Math.Min(rh, h); j++)
                            a[i, j] = true;

                        break;

                    case "rotate":
                        if (parts[1] == "row")
                        {
                            var ry = int.Parse(parts[2].Substring(2)); // removing "y="
                            var rby = int.Parse(parts[4]);
                            if (ry >= h)
                                continue;

                            var trow = new bool[w];
                            for (int x = 0; x < w; x++)
                                trow[(x + rby) % w] = a[x, ry];
                            for (int x = 0; x < w; x++)
                                a[x, ry] = trow[x];
                        }
                        else
                        {
                            var cx = int.Parse(parts[2].Substring(2)); // removing "x="
                            var cby = int.Parse(parts[4]);

                            if (cx >= w)
                                continue;
                            var tcol = new bool[h];
                            for (int y = 0; y < h; y++)
                                tcol[(y + cby) % h] = a[cx, y];
                            for (int y = 0; y < h; y++)
                                a[cx, y] = tcol[y];
                        }
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
            return a;
        }
    }
}