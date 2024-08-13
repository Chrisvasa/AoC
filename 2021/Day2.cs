namespace AoC._2021.Day2;

public class Day2
{
    public void Dive(string path)
    {
        string[] lines = ReadFile(path);
        int x = 0;
        int y = 0;
        int aim = 0;

        foreach (var line in lines)
        {
            int command = line.IndexOf(' ');
            int value = int.Parse(line.Substring(command + 1));
            switch (command)
            {
                case 2:
                    aim -= value;
                    break;
                case 4:
                    aim += value;
                    break;
                case 7:
                    x += value;
                    y += value * aim;
                    break;
            }
        }

        int result = x * y;
        Console.WriteLine($"X: {x} and Y: {y} and the result is: {result}");
    }
    
    private string[] ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException("File not found.");
        }

        string[] lines = File.ReadAllLines(path);
        return lines;
    }
}