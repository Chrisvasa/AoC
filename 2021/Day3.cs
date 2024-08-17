using AoC.Util;

namespace AoC._2021.Day3;

public class Day3
{
    private List<string> lines;
    private int width;
    public void BinaryDiagnostic()
    {
        FileManager fm = new FileManager("Day3", "2021");
        lines = fm.ReadFileAndReturnArray().ToList();
        width = lines[0].Length;

        Console.WriteLine(Part1());
        Console.WriteLine(Part2());
    }

    private int Part1()
    {
        string binary = "";
        string revBinary = "";

        for (int x = 0; x < width; x++)
        {
            int bit = GetMostCommonBit(lines, x);
            binary += bit;
            revBinary += (bit ^ 1);
        }
        return Convert.ToInt32(binary, 2) * Convert.ToInt32(revBinary, 2);
    }

    private int Part2()
    {
        int first = GetMostCommonBit(lines, 0);
        List<string> oxygen = lines.Where(s => s.StartsWith(first.ToString())).ToList();
        first ^= 1;
        List<string> scrubber = lines.Where(s => s.StartsWith(first.ToString())).ToList();
        for (int i = 1; i < width; i++)
        {
            char oc = (char)(GetMostCommonBit(oxygen, i) + 48);
            char sc = (char)(GetMostCommonBit(scrubber, i) + 48);
            if (oxygen.Count > 1)
                oxygen.RemoveAll(s => s[i] != oc);
            if (scrubber.Count > 1)
                scrubber.RemoveAll(s => s[i] == sc);
            if (oxygen.Count <= 1 && scrubber.Count <= 1) break;
        }

        return Convert.ToInt32(oxygen[0], 2) * Convert.ToInt32(scrubber[0], 2);
    }
    
    private int GetMostCommonBit(List<string> input, int x)
    {
        int numberOfOnes = 0;
        int numberOfItems = input.Count();
        
        for (int i = 0; i < numberOfItems; i++)
            numberOfOnes += (input[i][x] == '1') ? 1 : 0;

        if (numberOfItems % 2 == 0 && numberOfOnes == numberOfItems / 2)
            return 1;
        return (numberOfOnes < numberOfItems / 2.0) ? 0 : 1;
    }
    
    private void PrintItemsInList<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}