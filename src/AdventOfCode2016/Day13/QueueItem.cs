namespace AdventOfCode2016.Day13
{
    public sealed class QueueItem
    {
        public Location Location { get; }
        public uint Distance { get; }

        public QueueItem(Location location, uint distance)
        {
            Location = location;
            Distance = distance;
        }
    }
}
