using System.Diagnostics;

namespace AdventOfCode2016.Day2
{
    public sealed class Layout
    {
        private readonly char[,] _map;
        private readonly char _forbidenChar;
        private readonly int _width;
        private readonly int _height;

        private Layout(char[,] map, char forbidenChar)
        {
            _map = map; // TODO copy array
            _forbidenChar = forbidenChar;
            _width = map.GetLength(1);
            _height = map.GetLength(0);
        }

        public bool IsAllowed(Position position)
        {
            if (position.X < 0 || position.Y < 0)
                return false;
            if (position.X >= _width || position.Y >= _height)
                return false;

            return _map[position.Y, position.X] != _forbidenChar;
        }

        public char GetItem(Position position)
        {
            Debug.Assert(IsAllowed(position), "Shouldn't access to not allowed item");

            return _map[position.Y, position.X];
        }

        public static Layout CreateFromArray(char[,] map, char forbidenChar = '0')
        {
            return new Layout(map, forbidenChar);
        }
    }
}