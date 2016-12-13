using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016.Day7
{
    public sealed class IpAddress
    {
        public bool Tls { get; }
        public bool Ssl { get; }

        public IpAddress(bool tls, bool ssl)
        {
            Tls = tls;
            Ssl = ssl;
        }

        public static IpAddress Parse(string s)
        {
            return new IpAddress(IsTls(s), IsSsl(s));
        }

        private static bool IsSsl(string address)
        {
            var aba = new List<string>();
            var bab = new List<string>();

            bool result = false;
            bool inBrackets = false;
            for (int i = 0; i < address.Length - 2; i++)
            {
                if (inBrackets && address[i] == ']')
                {
                    inBrackets = false;
                    continue;
                }
                if (address[i] == '[')
                {
                    Debug.Assert(!inBrackets);
                    inBrackets = true;
                    continue;
                }

                if (address[i] != address[i + 1]
                    && address[i + 2] == address[i])
                {
                    if (inBrackets)
                        bab.Add(address.Substring(i, 3));
                    else
                        aba.Add(address.Substring(i, 3));
                }
            }

            foreach (var a in aba)
            {
                if (bab.Any(b => a[0] == b[1] && a[1] == b[0]))
                    return true;
            }

            return false;
        }

        private static bool IsTls(string address)
        {
            bool result = false;
            bool inBrackets = false;
            for (int i = 0; i < address.Length - 3; i++)
            {
                if (inBrackets && address[i] == ']')
                {
                    inBrackets = false;
                    continue;
                }
                if (address[i] == '[')
                {
                    Debug.Assert(!inBrackets);
                    inBrackets = true;
                    continue;
                }

                if (address[i] != address[i + 1]
                    && address[i + 2] == address[i + 1]
                    && address[i + 3] == address[i])
                {
                    if (inBrackets)
                        return false;
                    result = true;
                }
            }
            return result;
        }
    }
}