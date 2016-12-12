namespace AdventOfCode2016.Day2
{
    public sealed class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public Position Up()
        {
            return new Position(X, Y - 1);
        }

        public Position Down()
        {
            return new Position(X, Y + 1);
        }

        public Position Left()
        {
            return new Position(X - 1, Y);
        }

        public Position Right()
        {
            return new Position(X + 1, Y);
        }
    }
}
