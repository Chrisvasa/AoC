using System.Text.RegularExpressions;

namespace AoC.Day1;

public static class Day1
{
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
        { "nine",  9 }
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
        
        while (line is not null)
        {
            string num = line.FirstOrDefault(Char.IsDigit).ToString();
            num += line.LastOrDefault(Char.IsDigit).ToString();
    
            sum += int.Parse(num);
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
        string pattern = @"(?:1|2|3|4|5|6|7|8|9|one|two|three|four|five|six|seven|eight|nine)";
        int sum = 0;

        while (line is not null)
        {
            string? firstMatch = Regex.Match(line, pattern).Value;
            string? secondMatch = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
            
            if (!char.IsDigit(firstMatch[0]))
                firstMatch = numbers[firstMatch].ToString();
            if (!char.IsDigit(secondMatch[0]))
                secondMatch = numbers[secondMatch].ToString();
            
            firstMatch += secondMatch;
            sum += int.Parse(firstMatch);
            line = sr.ReadLine();
        }
        Console.WriteLine($"Sum is: {sum}");
        sr.Close();
    }
}
 

