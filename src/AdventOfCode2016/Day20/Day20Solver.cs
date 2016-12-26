using System;
using System.Diagnostics;

namespace AdventOfCode2016.Day20
{
    public sealed class Day20Solver
    {
        private ulong FullItem = 0xFFFFFFFFFFFFFFFF;
        private const int ItemBitsCount = sizeof(ulong) * 8;

        public int SolvePart1(string[] rules)
        {
            var buff = new ulong[4294967296 / ItemBitsCount];

            ProcessFirewallRules(rules, buff);

            for (var i = 0; i < buff.Length; i++)
            {
                if (buff[i] != FullItem)
                    return i * ItemBitsCount + GetFirstZeroBitIndex(buff[i]);
            }

            return 0;
        }

        public ulong SolvePart2(string[] rules)
        {
            var size = 67108864;
            var buff = new ulong[size];

            ProcessFirewallRules(rules, buff);

            ulong result = 0;
            for (var i = 0; i < buff.Length; i++)
            {
                if (buff[i] == 0)
                    result += ItemBitsCount;
                else
                    result += GetZeroBitCount(buff[i]);
            }

            return result;
        }

        private void ProcessFirewallRules(string[] rules, ulong[] buff)
        {
            foreach (var rule in rules)
            {
                var parts = rule.Split('-');
                Debug.Assert(parts.Length == 2);

                var from = long.Parse(parts[0]);
                var to = long.Parse(parts[1]);

                AddToBackList(buff, @from, to);
            }
        }

        private int GetFirstZeroBitIndex(ulong item)
        {
            var bitSet = 1UL;
            for (var bit = 0UL; bit < ItemBitsCount; bit++)
            {
                if ((~item & bitSet) > 0)
                    return (int) bit;
                bitSet = bitSet << 1;
            }
            return -1;
        }

        private ulong GetZeroBitCount(ulong item)
        {
            ulong result = 0;
            var bitSet = 1UL;
            for (var bit = 0UL; bit < ItemBitsCount; bit++)
            {
                if ((~item & bitSet) > 0)
                    result++;
                bitSet = bitSet << 1;
            }
            return result;
        }

        private void AddToBackList(ulong[] buff, long from, long to)
        {
            Debug.Assert(from < to);

            var toItemIndex = to / ItemBitsCount;
            var fromItemIndex = @from / ItemBitsCount;
            int toIndexInsideItem = (int) (to % ItemBitsCount);
            int fromIndexInsideItem = (int) (from % ItemBitsCount);

            if (toItemIndex == fromItemIndex)
            {
                buff[toItemIndex] = SetBits(buff[toItemIndex], fromIndexInsideItem, toIndexInsideItem);
                return;
            }

            // set first item bits
            buff[fromItemIndex] = SetBits(buff[fromItemIndex], fromIndexInsideItem, ItemBitsCount - 1);

            // set last item bits
            buff[toItemIndex] = SetBits(buff[toItemIndex], 0, toIndexInsideItem);
            
            // set bits from items
            var firstFullItem = fromIndexInsideItem == 0
                ? fromItemIndex
                : fromItemIndex + 1;
            var lastFullItem = toIndexInsideItem == (ItemBitsCount - 1)
                ? toItemIndex
                : toItemIndex - 1;

            for (var i = firstFullItem; i <= lastFullItem; i++)
                buff[i] = FullItem;
        }

        private ulong SetBits(ulong item, int from, int to)
        {
            var bitSet = 1UL;
            for (var i = from; i <= to; i++)
                item = item | (bitSet << i);

            return item;
        }
    }
}