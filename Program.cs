using System;
using static AoC.Day2.Day2;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"data\inputs\Day2.txt";
            string path = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).Parent.FullName, fileName);
            // Day1.Day1.PartOne(path);
            // Day1.Day1.PartTwo(path);
            ParseFile(path);
        }
    }
}