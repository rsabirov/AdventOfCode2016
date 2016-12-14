using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace AdventOfCode2016.Day13
{
    public sealed class Day13Solver
    {
        private readonly int[] _dx = { -1, 0, +1, 0 };
        private readonly int[] _dy = { 0, -1, 0, +1 };

        public uint SolvePart1(uint number, Location source, Location destination)
        {
            const int maxSize = 1000;
            uint[,] dist = new uint[maxSize, maxSize];
            var queue = new Queue<QueueItem>();

            queue.Enqueue(new QueueItem(source, 0));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var l = p.Location;

                if (dist[l.X, l.Y] != 0 && p.Distance >= dist[l.X, l.Y])
                    continue;

                dist[l.X, l.Y] = p.Distance;

                if (p.Location.X == destination.X && p.Location.Y == destination.Y)
                    break;

                for (int i = 0; i < _dx.Length; i++)
                {
                    var newLocation = new Location(l.X + _dx[i], l.Y + _dy[i]);
                    if (!newLocation.IsOnField)
                        continue;
                    if (dist[newLocation.X, newLocation.Y] > 0)
                        continue;
                    if (IsOpenSpace(newLocation, number))
                    {
                        queue.Enqueue(new QueueItem(newLocation, p.Distance + 1));
                    }
                }
            }

            return dist[destination.X, destination.Y];
        }

        public int SolvePart2(uint number, Location source, int distance)
        {
            const int maxSize = 1000;
            uint[,] dist = new uint[maxSize, maxSize];
            var queue = new Queue<QueueItem>();
            int result = 0;

            queue.Enqueue(new QueueItem(source, 0));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var l = p.Location;

                if (dist[l.X, l.Y] != 0 && p.Distance >= dist[l.X, l.Y])
                    continue;

                dist[l.X, l.Y] = p.Distance;

                if (p.Distance < distance)
                    result++;
                if (p.Distance == distance)
                    continue;

                for (int i = 0; i < _dx.Length; i++)
                {
                    var newLocation = new Location(l.X + _dx[i], l.Y + _dy[i]);
                    if (!newLocation.IsOnField)
                        continue;
                    if (dist[newLocation.X, newLocation.Y] > 0)
                        continue;
                    if (IsOpenSpace(newLocation, number))
                    {
                        queue.Enqueue(new QueueItem(newLocation, p.Distance + 1));
                    }
                }
            }

            return result;
        }

        private bool IsOpenSpace(Location location, uint number)
        {
            var x = (uint)location.X;
            var y = (uint)location.Y;
            ulong exp = x * x + 3 * x + 2 * x * y + y + y * y + number;

            var oneBitsCount = GetOneBitsCount(exp);
            return oneBitsCount % 2 == 0;
        }

        private int GetOneBitsCount(ulong number)
        {
            var result = 0;
            ulong mask = 1;
            for (int i = 0; i < sizeof(ulong) * 8; i++)
            {
                if ((number & (mask << i)) > 0)
                    result++;
            }
            return result;
        }
    }
}