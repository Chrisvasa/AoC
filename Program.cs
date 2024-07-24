using System;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"data\inputs\Day1.txt";
            string path = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).Parent.FullName, fileName);
            Day1.Day1.PartOne(path);
            Day1.Day1.PartTwo(path);
        }
    }
}