using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Day4
{
    public sealed class EncryptedName
    {
        private static readonly Regex ParseRegex = new Regex(
            @"^(?<name>[a-z-]+)-(?<id>\d+)\[(?<checksum>\w+)\]$",
            RegexOptions.Compiled | RegexOptions.Singleline);

        public string Name { get; }
        public string Checksum { get; }
        public int Id { get; }

        public bool IsReal
        {
            get
            {
                var allChars = Name
                    .Where(c => c != '-')
                    .GroupBy(c => c, (c, items) => new {Char = c, Count = items.Count()})
                    .OrderByDescending(item => item.Count)
                    .ThenBy(arg => arg.Char);

                var top5Chars = allChars
                    .Take(5)
                    .Select(arg => arg.Char)
                    .ToArray();
                return Checksum.All(c => top5Chars.Contains(c));
            }
        }

        public string DecryptedName
        {
            get
            {
                var builder = new StringBuilder();
                foreach (char c in Name)
                {
                    if (c == '-')
                        builder.Append(" ");
                    else
                        builder.Append(GetShifted(c, Id));
                }

                return builder.ToString();
            }
        }

        private char GetShifted(char c, int shift)
        {
            var count = 'z' - 'a' + 1;
            var index = c - 'a';
            var shiftedIndex = (index + shift) % count;

            return (char) ('a' + shiftedIndex);
        }

        public EncryptedName(string name, string checksum, int id)
        {
            Name = name;
            Checksum = checksum;
            Id = id;

            Debug.Assert(checksum.Length == 5);
        }

        public static EncryptedName Parse(string s)
        {
            var match = ParseRegex.Match(s);
            Debug.Assert(match.Success, "Cannot parse");

            return new EncryptedName(match.Groups["name"].Value,
                match.Groups["checksum"].Value, int.Parse(match.Groups["id"].Value));
        }
    }
}