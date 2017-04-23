using System;

namespace Task2_1_2_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareCollections compareCollections = new CompareCollections(20000);
            string report = compareCollections.Compare();
            Console.WriteLine(report);
            Console.ReadKey();
        }
    }
}
