using System;

namespace AssetSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Suite suite = new Suite())
                suite.Run();
        }
    }
}