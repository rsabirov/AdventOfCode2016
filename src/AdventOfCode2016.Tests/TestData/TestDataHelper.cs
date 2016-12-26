using System.IO;
using NUnit.Framework;

namespace AdventOfCode2016.Tests.TestData
{
    public static class TestDataHelper
    {
        public static string GetPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, 
                @"..\..\..\..\TestData\", fileName);

        }
    }
}
