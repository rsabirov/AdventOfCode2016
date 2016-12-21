using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2016.Day21
{
    public sealed class Day21Solver
    {
        public string SolvePart1(string initial, string[] commands)
        {
            return ExecuteCommands(initial, commands);
        }

        public string SolvePart2(string initial, string[] commands)
        {
            return ExecuteCommands(initial, commands, inReverseOrder: true);
        }

        private static string ExecuteCommands(string initial, string[] commands, bool inReverseOrder = false)
        {
            var buffer = new StringBuilder(initial);
            var commandsInOrder = inReverseOrder ? commands.Reverse() : commands;
            foreach (var command in commandsInOrder)
            {
                string operation;
                string[] parameters;
                ParseOperationAndParameters(command, out operation, out parameters);

                switch (operation)
                {
                    case "swap position":
                        SwapPosition(buffer, parameters, inReverseOrder);
                        break;

                    case "swap letter":
                        SwapLetter(buffer, parameters, inReverseOrder);
                        break;

                    case "rotate based":
                        RotateBasedOnPositionOfLetter(buffer, parameters, inReverseOrder);
                        break;

                    case "rotate left":
                        RotateLeft(buffer, parameters, inReverseOrder);
                        break;

                    case "rotate right":
                        RotateRight(buffer, parameters, inReverseOrder);
                        break;

                    case "reverse positions":
                        ReversePositions(buffer, parameters, inReverseOrder);
                        break;

                    case "move position":
                        MovePosition(buffer, parameters, inReverseOrder);
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            return buffer.ToString();
        }

        private static void MovePosition(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var x = int.Parse(parameters[0]);
            var y = int.Parse(parameters[3]);

            if (inReverseOrder)
                Swap(ref x, ref y);

            var t = buffer[x];
            buffer.Remove(x, 1);
            buffer.Insert(y, t);
        }

        private static void ReversePositions(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var x = int.Parse(parameters[0]);
            var y = int.Parse(parameters[2]);

            var min = Math.Min(x, y);
            var max = Math.Max(x, y);

            for (int i = min; i <= (min + max) / 2; i++)
            {
                var t = buffer[i];
                buffer[i] = buffer[max - (i - min)];
                buffer[max - (i - min)] = t;
            }
        }

        private static void RotateRight(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var steps = int.Parse(parameters[0]);
            Rotate(buffer, inReverseOrder ? -1 : 1, steps);
        }

        private static void RotateLeft(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var steps = int.Parse(parameters[0]);
            Rotate(buffer, inReverseOrder ? 1 : -1, steps);
        }

        private static void RotateBasedOnPositionOfLetter(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var x = parameters[4].Single();
            int pos;
            for (pos = 0; pos < buffer.Length; pos++)
            {
                if (buffer[pos] == x)
                    break;
            }
            Debug.Assert(pos != buffer.Length);

            var direction = 1;
            var steps = StepsFromPos(pos);

            if (inReverseOrder)
            {
                for (int posToCheck = 0; posToCheck < buffer.Length; posToCheck++)
                {
                    var stepsForPosToCheck = StepsFromPos(posToCheck);
                    var newIndex = GetNewIndex(buffer, 1, stepsForPosToCheck, posToCheck);
                    if (newIndex == pos)
                    {
                        steps = Math.Abs(posToCheck - pos);
                        direction = posToCheck > pos ? 1 : -1;
                    }
                }
            }

            Rotate(buffer, direction, steps);
        }

        private static int StepsFromPos(int pos)
        {
            return 1 + pos + (pos >= 4 ? 1 : 0);
        }

        private static void Rotate(StringBuilder buffer, int direction, int steps)
        {
            var additionBuffer = new char[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                var newIndex = GetNewIndex(buffer, direction, steps, i);
                additionBuffer[newIndex] = buffer[i];
            }
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = additionBuffer[i];
        }

        private static int GetNewIndex(StringBuilder buffer, int direction, int steps, int index)
        {
            return ((index + steps * direction) % buffer.Length + buffer.Length) % buffer.Length;
        }

        private static void SwapLetter(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var x = parameters[0].Single();
            var y = parameters[3].Single();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == x)
                    buffer[i] = y;
                else if (buffer[i] == y)
                    buffer[i] = x;
            }
        }

        private static void SwapPosition(StringBuilder buffer, string[] parameters, bool inReverseOrder)
        {
            var x = int.Parse(parameters[0]);
            var y = int.Parse(parameters[3]);

            var t = buffer[x];
            buffer[x] = buffer[y];
            buffer[y] = t;
        }

        private static void ParseOperationAndParameters(string command, out string operation, out string[] parameters)
        {
            var parts = command.Split(' ');
            operation = parts[0] + " " + parts[1];
            parameters = parts.Skip(2).ToArray();
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var t = a;
            a = b;
            b = t;
        }
    }
}