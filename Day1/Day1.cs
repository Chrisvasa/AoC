using System.Text.RegularExpressions;

namespace AoC.Day1;

public static class Day1
{
    // Refactor - Added kvp for 1-9 as digits as well
    private static Dictionary<string, int> numbers = new Dictionary<string, int>
    {
        { "one",   1 },
        { "two",   2 },
        { "three", 3 },
        { "four",  4 },
        { "five",  5 },
        { "six",   6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine",  9 },
        { "1",     1 },
        { "2",     2 },
        { "3",     3 },
        { "4",     4 },
        { "5",     5 },
        { "6",     6 },
        { "7",     7 },
        { "8",     8 },
        { "9",     9 }
    };
    
    public static void PartOne(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Could not find file.");
            return;
        }
        
        StreamReader sr = new StreamReader(path);
        string? line = sr.ReadLine();
        int sum = 0;
        
        // Refactor - Changed from strings to ints
        // And now go straight from char to int instead
        while (line is not null)
        {
            int num = (line.FirstOrDefault(Char.IsDigit) - 48) * 10;
            num += line.LastOrDefault(Char.IsDigit) - 48;
    
            sum += num;
            line = sr.ReadLine();
        }
    
        Console.WriteLine($"Sum is: {sum}");
        sr.Close();
    }
    
    public static void PartTwo(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Could not find file.");
            return;
        }
        
        StreamReader sr = new StreamReader(path);
        string? line = sr.ReadLine();
        string pattern = @"(?:[1-9]|one|two|three|four|five|six|seven|eight|nine)";
        int sum = 0;

        while (line is not null)
        {
            string? firstMatch = Regex.Match(line, pattern).Value;
            string? secondMatch = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
            
            // Minor refactor - No longer check if digit since we changed the dictionary keys
            // Also changed from firstMatch, secondMatch strings to int num
            int num = numbers[firstMatch] * 10;
            num += numbers[secondMatch];

            sum += num;
            line = sr.ReadLine();
        }
        Console.WriteLine($"Sum is: {sum}");
        sr.Close();
    }
}
 

