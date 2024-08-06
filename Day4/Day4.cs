namespace AoC.Day4;

public class Day4
{
    private static string[] _lines;
    private static int _maxLength;
    private static int sum = 0;

    public static void Scratchcards(string path)
    {
        ReadFile(path);
        for (int i = 0; i < _maxLength; i++)
        {
            int count = 0;
            string[] temp = _lines[i].Split(':')[1].Split('|');
            string[] numbers = temp[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] winning = temp[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var num in numbers)
            {
                if (winning.Contains(num))
                {
                    if (count == 0)
                        count++;
                    else
                        count *= 2;
                }
            }
            sum += count;
        }
        Console.WriteLine(sum);
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