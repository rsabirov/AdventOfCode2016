using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2016.Day5
{
    public sealed class Day5Solver
    {
        public string SolvePart1(string id)
        {
            var result = new StringBuilder();
            var input = new byte[1000];
            var encoding = Encoding.ASCII;

            using (var md5 = MD5.Create())
            {
                for (long i = 0; i < 10 * 1000 * 1000 * 100; i++)
                {
                    var currentString = id + i;
                    var len = encoding.GetBytes(currentString, 0, currentString.Length, input, 0);
                    var hash = md5.ComputeHash(input, 0, len);

                    if (hash[0] == 0 && hash[1] == 0 && hash[2] <= 15)
                    {
                        var ch = hash[2].ToString("x");
                        result.Append(ch);

                        if (result.Length == 8)
                            break;
                    }
                }
            }

            return result.ToString();
        }

        public string SolvePart2(string id)
        {
            var result = new char[8];
            var input = new byte[1000];
            var encoding = Encoding.ASCII;
            var count = 0;

            using (var md5 = MD5.Create())
            {
                for (long i = 0; i < 10 * 1000 * 1000 * 100; i++)
                {
                    var currentString = id + i;
                    var len = encoding.GetBytes(currentString, 0, currentString.Length, input, 0);
                    var hash = md5.ComputeHash(input, 0, len);

                    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 8)
                    {
                        var pos = hash[2];
                        var c = hash[3] / 16;
                        if (result[pos] == 0)
                        {
                            result[pos] = c.ToString("x")[0];
                            count++;

                            if (count == 8)
                                break;
                        }
                    }
                }
            }

            return new string(result);
        }
    }
}
