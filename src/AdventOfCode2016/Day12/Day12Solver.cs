using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2016.Day12
{
    public sealed class Day12Solver
    {
        private readonly Dictionary<string, int> _registers = new Dictionary<string, int>();

        public Day12Solver()
        {
            _registers.Add("a", 0);
            _registers.Add("b", 0);
            _registers.Add("c", 0);
            _registers.Add("d", 0);
        }

        public int SolvePart1(string[] lines)
        {
            ExecuteAsm(lines);
            return Get("a");
        }

        public int SolvePart2(string[] lines)
        {
            Set("c", 1);
            ExecuteAsm(lines);
            return Get("a");
        }

        private void ExecuteAsm(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(' ');
                var command = parts[0];
                var r1 = parts[1];

                switch (command)
                {
                    case "cpy":
                        var copyTo = parts[2];
                        int num;
                        if (int.TryParse(r1, out num))
                            Set(copyTo, num);
                        else
                            Set(copyTo, Get(r1));
                        break;
                    case "inc":
                        Set(r1, Get(r1) + 1);
                        break;
                    case "dec":
                        Set(r1, Get(r1) - 1);
                        break;
                    case "jnz":
                        var jumpOffset = int.Parse(parts[2]);
                        int numberToCompare;
                        if (!int.TryParse(r1, out numberToCompare))
                            numberToCompare = Get(r1);

                        if (numberToCompare != 0)
                        {
                            i += jumpOffset - 1;
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private int Get(string registerName)
        {
            Debug.Assert(_registers.ContainsKey(registerName),
                string.Format("Register '{0}' is not exists", registerName));
            return _registers[registerName];
        }

        private void Set(string registerName, int value)
        {
            Debug.Assert(_registers.ContainsKey(registerName));
            _registers[registerName] = value;
        }
    }
}