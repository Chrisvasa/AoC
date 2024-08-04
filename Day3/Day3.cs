using System.Diagnostics;
using System.Text;
using System.Threading.Channels;

namespace AoC.Day3;

public static class Day3
{
    private static string[]? _lines;
    private static int _maxLength;
    private static int sumPart = 0;
    private static int sumGear = 0;

    public static void Solve(string path)
    {
        ReadFile(path);
        
        for (int i = 0; i < _maxLength; i++)
        {
            for (int j = 0; j < _maxLength; j++)
            {
                // if (_lines[i][j] == '*')
                // {
                //     FindAdjacentNumbers(i, j);
                // }

                if (!char.IsLetterOrDigit(_lines[i][j]) && _lines[i][j] != '.')
                {
                    FindAdjacentNumbers(i, j);
                }
            }
        }
    }
    
    private static void ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Could not open file!");
            return;
        }

        _lines = File.ReadAllLines(path);
        _maxLength = _lines.Length;
    }

    private static void FindAdjacentNumbers(int lineY, int lineX)
    {
        int minRow = Math.Max(0, lineY - 1);
        int maxRow = Math.Min(_maxLength - 1, lineY + 1);
        int minCol = Math.Max(0, lineX - 1);
        int maxCol = Math.Min(_maxLength - 1, lineX + 1);

        for (int y = minRow; y <= maxRow; y++)
        {
            for (int x = minCol; x <= maxCol; x++)
            {
                if (char.IsDigit(_lines[y][x]))
                {
                    FindStart(ref x, _lines[y]);
                    int temp = GetNumber(ref x, _lines[y]);
                    if (temp != - 1)
                        Console.WriteLine(temp);
                }
            }
        }
    }
    
    private static int GetNumber(ref int x, string line)
    {
        string num = "";
        while (x < _maxLength && char.IsDigit(line[x]))
        {
            num += line[x++];
        }

        if (!string.IsNullOrWhiteSpace(num))
        {
            return int.Parse(num);
        }

        return -1;
    }
    
    // Method that finds the beginning of a given number
    private static void FindStart(ref int x, string line)
    {
        while (x > 0 && char.IsDigit(line[x - 1]))
            x--;
    }
}