using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace AoC.Day3;

public static class Day3
{
    private static int _maxLength;
    public static void PartOne(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] line = File.ReadAllLines(path);
        StringBuilder currNum = new StringBuilder();
        _maxLength = line.Length;
        int sum = 0;

        var sw = new Stopwatch();
        sw.Start();
        
        for (int i = 0; i < _maxLength; i++)
        {
            for (int j = 0; j < _maxLength; j++)
            {
                if (Char.IsDigit(line[i][j]))
                {
                    while (j < _maxLength && Char.IsDigit(line[i][j]))
                        currNum.Append(line[i][j++]);
                    
                    if (SearchAdjacent(ref line, currNum.Length, i, j))
                        sum += int.Parse(currNum.ToString());
                    currNum.Clear();
                }
            }
        }
        sw.Stop();
        Console.WriteLine(sum);
        Console.WriteLine($"It took: {sw.ElapsedMilliseconds} ms to search the file.");
    }

    static bool SearchAdjacent(ref string[] line, int numLength, int row, int col)
    {
        // Gets the start and end index for row (row - 1, row and row + 1 if possible)
        int start = (row > 0) ? row - 1 : row; 
        int end = (row < _maxLength - 1) ? row + 1 : row;
        // Gets the start and end of the current number we are checking adjacent values to
        // Since we are passing the END index of the number in col, we are making sure that the value before
        // and after are within bounds of the array
        int s = (col - numLength - 1 >= 0) ? col - numLength - 1 : col;
        int e = (col < _maxLength - 1) ? col + 1 : col;
        
        for (int i = start; i <= end; i++)
            for (int j = s; j < e; j++)
                if ((Char.IsSymbol(line[i][j]) || Char.IsPunctuation(line[i][j]) || Char.IsSeparator(line[i][j])) && line[i][j] != '.') 
                    return true;
        return false;
    }
}

/*
 * Find adjacent numbers to a symbol.
 * Find symbols and search their surroundings?
 *
 * [ - s s s - - ]
 * [ - s * s - - ]
 * [ - s s s - - ]
 * Symbol on row 2, and then search adjacent "boxes"
 *
 * How to handle "edge-cases"?
*/