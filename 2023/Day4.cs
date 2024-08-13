using System.Diagnostics;
using AoC.Util;

namespace AoC.Day4;

public class Day4
{
    private static string[] _lines;
    private static int _maxLength;

    // Will refactor to improve performance... this is a disaster, but it works and was fast to code :D
    public static void Scratchcards()
    {
        FileManager fm = new FileManager("Day4", "2023");
        ReadFile(fm.FilePath);
        int sum = 0;
        int bumSum = 0;
        int[] timesToRun = new int[_maxLength];
        
        Stopwatch sw = new Stopwatch();
        sw.Start();
        
        for (int i = 0; i < _maxLength; i++)
        {
            int count = 0;
            int index = 1;
            string[] temp = _lines[i].Split(':')[1].Split('|');
            string[] numbers = temp[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] winning = temp[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            timesToRun[i]++;

            foreach (var num in numbers)
            {
                if (winning.Contains(num))
                {
                    if (count == 0)
                        count++;
                    else
                        count *= 2;
                    timesToRun[i + index++] += 1 * timesToRun[i];
                }
            }
            bumSum += timesToRun[i];
            sum += count;
        }
        sw.Stop();
        Console.WriteLine(sum);
        Console.WriteLine(bumSum);
        Console.WriteLine($"To find both sums took {sw.ElapsedMilliseconds} ms.");
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
}