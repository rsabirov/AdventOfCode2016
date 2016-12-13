using System.Linq;

namespace AdventOfCode2016.Day7
{
    public class Day7Solver
    {
        public int SolverPart1(string[] ipAddresses)
        {
            return ipAddresses
                .Select(IpAddress.Parse)
                .Count(address => address.Tls);
        }

        public int SolverPart2(string[] ipAddresses)
        {
            return ipAddresses
                .Select(IpAddress.Parse)
                .Count(address => address.Ssl);
        }
    }
}