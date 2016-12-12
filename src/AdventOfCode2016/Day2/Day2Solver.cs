using System;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2016.Day2
{
    public class Day2Solver
    {
        private readonly Layout _layout;

        public Day2Solver(Layout layout)
        {
            if (layout == null)
                throw new ArgumentNullException(nameof(layout));
            _layout = layout;
        }

        public string GetAnswer(string[] instructions, Position position)
        {
            Debug.Assert(_layout.IsAllowed(position), "Starting position is not allowed");

            var currentPosition = position;
            var resultBuilder = new StringBuilder();
            foreach (var instruction in instructions)
            {
                currentPosition = FollowTheInstruction(instruction, currentPosition);
                resultBuilder.Append(_layout.GetItem(currentPosition));
            }
            return resultBuilder.ToString();
        }

        private Position FollowTheInstruction(string instruction, Position currentPosition)
        {
            foreach (var command in instruction)
            {
                Position nextPosition;
                switch (command)
                {
                    case 'U':
                        nextPosition = currentPosition.Up();
                        break;
                    case 'D':
                        nextPosition = currentPosition.Down();
                        break;
                    case 'L':
                        nextPosition = currentPosition.Left();
                        break;
                    case 'R':
                        nextPosition = currentPosition.Right();
                        break;
                    default:
                        throw new InvalidOperationException("Unsupported instruction");
                }

                if (_layout.IsAllowed(nextPosition))
                    currentPosition = nextPosition;
            }
            return currentPosition;
        }
    }
}
