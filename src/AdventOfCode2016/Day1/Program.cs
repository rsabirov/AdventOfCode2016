using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter path in following format ' R1, L5, L4, R5, R3, L1':");
            //var path = Console.ReadLine();
            var path = File.ReadAllText("input1.txt");

            var commands = path.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var x = 0;
            var y = 0;
            var directionAngle = 0.0;
            var visited = new Dictionary<Tuple<int, int>, int>();
            visited.Add(new Tuple<int, int>(0, 0), 0);

            for (int index = 0; index < commands.Length; index++)
            {
                var command = commands[index];
                var direction = command[0];
                var steps = int.Parse(command.Substring(1));

                switch (direction)
                {
                    case 'L':
                        directionAngle += 90;
                        break;

                    case 'R':
                        directionAngle -= 90;
                        break;

                    default:
                        throw new InvalidOperationException();
                }

                int dx = (int) Math.Cos(directionAngle*(Math.PI/180));
                int dy = (int) Math.Sin(directionAngle*(Math.PI/180));

                for (int i = 0; i < steps; i++)
                {
                    x = x + dx;
                    y = y + dy;

                    var point = new Tuple<int, int>(x, y);
                    if (visited.ContainsKey(point))
                    {
                        var prevIndex = visited[point];

                        Console.WriteLine(Math.Abs(x) + Math.Abs(y));

                        //Console.WriteLine(index + 1 - prevIndex);
                        return;
                    }

                    visited.Add(point, index + 1);
                }
            }

            //Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }
    }
}