namespace AdventOfCode2016.Day13
{
    public sealed class Location
    {
        public int X { get; }
        public int Y { get; }
        public bool IsOnField => X >= 0 && Y >= 0;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}