namespace AdventOfCode2016.Day16
{
    public sealed class Day16Solver
    {
        public string Solve(string initialState, int len)
        {
            var data = new Data(initialState);

            while (data.Length < len)
                data.Next();
            data.TrimLength(len);

            var checkSum = data.CalcChecksum();
            return Data.AsString(checkSum);
        }
    }
}