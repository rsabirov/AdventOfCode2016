using System;
using System.Linq;

namespace AdventOfCode2016.Day19
{
    public sealed class Day19Solver
    {
        public int SolvePart1(int count)
        {
            var head = CreateElfs(count);

            var current = head;
            while (current != current.Next)
            {
                var next = current.Next;
                current.Presents += next.Presents;

                // remove next
                Console.WriteLine("Removing {0}", current.Next.Number);
                RemoveNext(current);

                current = current.Next;
            }

            return current.Number;
        }

        public int SolvePart2(int count)
        {
            Elf head = CreateElfs(count);

            Elf opposite = head;
            int oppositeIndex = count / 2;
            for (int i = 0; i < oppositeIndex; i++)
                opposite = opposite.Next;
            Console.WriteLine("First opposite for count {0} is {1}", count, opposite.Number);

            var current = head;
            var del = count % 2 == 1;
            while (current != current.Next)
            {
                current.Presents += opposite.Presents;

                // remove opposite
                RemoveItem(ref opposite);

                current = current.Next;
                if (del)
                    opposite = opposite.Next;
                del = !del;
            }

            return current.Number;
        }

        private void RemoveItem(ref Elf current)
        {
            var next = current.Next;
            next.Prev = current.Prev;
            next.Prev.Next = next;

            current = next;
        }

        private static void RemoveNext(Elf current)
        {
            current.Next = current.Next.Next;
            current.Next.Prev = current;
        }

        private static Elf CreateElfs(int count)
        {
            Elf head = new Elf(1, 1);
            Elf current = head;
            foreach (var num in Enumerable.Range(2, count - 1))
            {
                current.Next = new Elf(num, 1)
                {
                    Prev = current
                };

                current = current.Next;
            }
            current.Next = head;
            head.Prev = current;
            return head;
        }
    }
}