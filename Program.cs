using System;
using static AoC.Day1.Day1;
using static AoC.Day2.Day2;
using static AoC.Day3.Day3;
using static AoC.Day4.Day4;
using static AoC.Day5.Day5;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"data\Day5.txt";
            string path = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).Parent.FullName, fileName);
            // Day 1
            // PartOne(path);
            // PartTwo(path);
            
            // Day 2
            // ParseFile(path);
            // PartOne(path);
            
            // Day 3
            // GearRatios(path);
            
            // Day 4
            // Scratchcards(path);
            
            // Day 5
            Fertilizer(path);
        }
    }
}