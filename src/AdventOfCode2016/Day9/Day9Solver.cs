using System.Linq;
using System.Text;

namespace AdventOfCode2016.Day9
{
    public sealed class Day9Solver
    {
        public int Day9SolvePart1(string compressedData)
        {
            var uncompressedData = Uncompress(compressedData);

            return uncompressedData.Count(c => !char.IsWhiteSpace(c));
        }

        public long Day9SolvePart2(string compressedData)
        {
            return Count(compressedData, 0, compressedData.Length);
        }

        private static string Uncompress(string compressedData)
        {
            var buffer = new StringBuilder();
            for (int pos = 0; pos < compressedData.Length;)
            {
                if (compressedData[pos] != '(')
                    buffer.Append(compressedData[pos++]);
                else
                {
                    var markerEnd = compressedData.IndexOf(")", pos);
                    var markerParts = compressedData
                        .Substring(pos + 1, markerEnd - pos - 1)
                        .Split('x');

                    var len = int.Parse(markerParts[0]);
                    var repeat = int.Parse(markerParts[1]);

                    var repeatedText = compressedData.Substring(markerEnd + 1, len);
                    for (int i = 0; i < repeat; i++)
                        buffer.Append(repeatedText);

                    pos = markerEnd + 1 + len;
                }
            }

            return buffer.ToString();
        }

        private static long Count(string compressedData, int start, int len)
        {
            var answer = 0L;
            for (int pos = start; pos < start + len;)
            {
                if (compressedData[pos] != '(')
                {
                    answer++;
                    pos++;
                }
                else
                {
                    var markerEnd = compressedData.IndexOf(")", pos);
                    var markerParts = compressedData
                        .Substring(pos + 1, markerEnd - pos - 1)
                        .Split('x');

                    var repeatLen = int.Parse(markerParts[0]);
                    var repeatCount = int.Parse(markerParts[1]);

                    answer += Count(compressedData, markerEnd + 1, repeatLen) * repeatCount;
                    pos = markerEnd + 1 + repeatLen;
                }
            }

            return answer;
        }
    }
}