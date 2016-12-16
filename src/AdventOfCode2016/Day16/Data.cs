using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016.Day16
{
    public sealed class Data
    {
        private bool[] _a;

        public int Length => _a.Length;

        public Data(string input)
        {
            _a = input.Select(c => c == '1').ToArray();
        }

        public void Next()
        {
            var result = new bool[Length * 2 + 1];
            for (int i = 0; i < Length; i++)
            {
                result[i] = _a[i];
                result[Length + 1 + i] = !_a[Length - i - 1];
            }

            _a = result;
        }

        public void TrimLength(int length)
        {
            var newA = new bool[length];
            Array.Copy(_a, newA, length);
            _a = newA;
        }

        public bool[] CalcChecksum()
        {
            Debug.Assert(Length % 2 == 0);

            var data = _a;
            bool[] checkSum;

            do
            {
                checkSum = new bool[data.Length / 2];

                for (int i = 0; i < data.Length; i += 2)
                    checkSum[i / 2] = data[i] == data[i + 1];

                data = checkSum;
            } while (checkSum.Length % 2 == 0);

            return checkSum;
        }

        public string AsString()
        {
            return AsString(_a);
        }

        public static string AsString(bool[] data)
        {
            return new string(data.Select(b => b ? '1' : '0').ToArray());
        }
    }
}
