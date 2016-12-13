using System.Linq;

namespace AdventOfCode2016.Day7
{
    public class Day7Solver
    {
        public int SolvePart1(string[] ipAddresses)
        {
            return ipAddresses
                .Select(IpAddress.Parse)
                .Count(address => address.Tls);
        }

        public int SolvePart2(string[] ipAddresses)
        {
            return ipAddresses
                .Select(IpAddress.Parse)
                .Count(address => address.Ssl);
        }
    }
}